using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace SimpleCrawler
{
    public delegate void PageDownloadEventHandler(string url);
    public delegate void PageDownloadErrorEventHandler(string message);

    public class Crawler
    {
        public ConcurrentBag<Task> tasks = new ConcurrentBag<Task>();

        public Stopwatch sw = new Stopwatch();

        private ConcurrentQueue<string> pending = new ConcurrentQueue<string>();
        private ConcurrentDictionary<string, bool> urls = new ConcurrentDictionary<string, bool>();

        private int count = 0;
        private int maxUrlNum = 100;

        private string startUrl;
        public string StartUrl { get => startUrl; set => startUrl = value; }

        public event PageDownloadEventHandler PageDownloaded;
        public event PageDownloadErrorEventHandler PageDownloadMessage;

        public Crawler()
        {
        }

        public Crawler(string startUrl)
        {
            AddStartUrl(startUrl);
        }

        public void AddStartUrl(string startUrl)
        {
            count = 0;
            urls.Clear();
            sw.Reset();

            // 将pending清空
            while(!pending.IsEmpty)
            {
                pending.TryDequeue(out string result);
            }

            startUrl = UrlService.FindAbsolutePath("", startUrl);   // 如果没有https，则加上
            this.startUrl = startUrl;

            urls.TryAdd(startUrl, false);
            pending.Enqueue(startUrl);
        }

        private bool IfAllTaskCompleted()
        {
            lock(this)
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    if (!tasks.ToArray()[i].IsCompleted)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public void Crawl()
        {
            while (count < maxUrlNum + 1) 
            {
                if (pending.Count == 0)
                {
                    if (IfAllTaskCompleted())
                    {
                        break;
                    }

                    continue;
                }

                pending.TryDequeue(out string current);

                Task newTask = new Task(() => CrawlNext(current));
                newTask.Start();
                tasks.Add(newTask);
            }

            //Task.WaitAll(tasks.ToArray());

            sw.Stop();

            Exception endException = new Exception($"爬取结束，共爬取到{count - 1}个网站，共用时{sw.ElapsedMilliseconds}ms。");
            PageDownloadMessage(endException.Message);
        }

        private void CrawlNext(string current)
        {
            if(count>maxUrlNum)
            {
                return;
            }

            string html = "";

            try
            {
                html = DownLoad(current);      // 下载
                PageDownloaded(current);
                lock(this)
                {
                    count++;
                }
            }
            catch (Exception ex)
            {
                html = "";
                PageDownloadMessage(ex.Message);
            }
            finally
            {
                urls.TryUpdate(current, true, false);

                Parse(html, current);    //解析,并加入新的链接
            }
        }

        private string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;

                string html = webClient.DownloadString(url);
                lock(this)
                {
                    string fileName = count.ToString();
                    File.WriteAllText(fileName, html, Encoding.UTF8);
                }

                return html;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Parse(string html,string current)
        {
            string strRef = @"(href|HREF)[ ]*=[ ]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);

            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)    //从=后开始，取子串
                          .Trim('"', '\"', '#', '>');   //去掉首位的空格和特殊符号

                if (strRef.Length == 0)
                {
                    continue;
                }
                
                if(!UrlService.IsHtml(strRef))       // 如果不是html文档
                {
                    continue;
                }

                string absolutePath = UrlService.FindAbsolutePath(current, strRef);

                if(!absolutePath.StartsWith(startUrl))    // 如果不是起始网页上的网页
                {
                    continue;
                }

                if (!urls.ContainsKey(absolutePath))
                {
                    urls.TryAdd(absolutePath, false);
                    pending.Enqueue(absolutePath);
                }
            }
        }
    }
}
