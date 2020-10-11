using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCrawler
{
    // 域名处理类
    public static class UrlService
    {
        // 找到最根目录
        public static string FindRoot(string current)
        {
            // 默认current是绝对路径
            int endIndex = current.IndexOf('/', 8);

            return current.Substring(0, endIndex);
        }

        // 去除url中的协议字段
        public static string DropProtocol(string url)
        {
            string pattern = @"(http:|https:)//";

            Match match = Regex.Match(url, pattern);

            int start = match.Index + match.Length;

            return url.Substring(start);
        }

        // 查询此url有几层，从0开始
        public static int FindLayerLength(string url)
        {
            url = DropProtocol(url);    // 去除协议字段
            url = url.Trim('/');        // 去除首尾多余的/字符

            return url.Count(p => p == '/');
        }

        // 去到指定层数
        public static string GoTo(string url,int layer)
        {
            if (FindLayerLength(url) < layer) 
            {
                throw new Exception();
            }

            // 如果layer小于0，返回根路径
            if (layer < 0) 
            {
                return FindRoot(url);
            }

            url = url.TrimEnd('/') + '/';

            string pattern = @"(http:|https:)//";

            Match match = Regex.Match(url, pattern);

            int start = match.Index + match.Length;
            int end = 0;

            for (int i = 0; i <= layer; i++)  
            {
                end = url.IndexOf('/', start);

                start = end + 1;
            }

            string result = url.Substring(0, end + 1);
            result = result.Trim('/');

            return result;
        }

        // 判断是否是html文档
        public static bool IsHtml(string url)
        {
            string pattern = @"\.htm[l?#]*.*$";

            return Regex.IsMatch(url, pattern);
        }

        // 判断是否是绝对路径，如果是，则删除多余字符并返回；如果是相对路径，则返回其绝对路径
        // current默认是绝对路径
        public static string FindAbsolutePath(string current, string url)
        {
            current = current.Trim('/');          // 去除current前后的空格和斜杠
            url = url.TrimEnd('/');               // 去除url前后的空格以及最后的斜杠

            int currentLayer = UrlService.FindLayerLength(current);
            if (Regex.IsMatch(current, @"\.htm[l?#]*.*$"))
            {
                current = UrlService.GoTo(current, currentLayer - 1);
                currentLayer--;
            }

            // 如果是绝对路径
            if (Regex.IsMatch(url, @"(http|https)://"))
            {
                return url.Trim('/');
            }

            // 如果以//开头，可以直接访问，根据当前页面的请求协议在头部自动加上url协议
            if (url.StartsWith("//"))
            {
                return @"https:" + url;
            }

            // 如果以./开头，表示当前路径
            if (url.StartsWith("./"))
            {
                return current + url.Trim('.');
            }

            // 如果以/开头的，证明在根目录下面
            if(url.StartsWith("/"))
            {
                return UrlService.FindRoot(current) + url;
            }

            // 如果以../开头的，表示上一级路径
            if(url.StartsWith("../"))
            {
                MatchCollection matches = new Regex(@"\.\./").Matches(url);
                int backLayerNum = matches.Count;   // "../"的个数，即退回的层数

                return UrlService.GoTo(current, currentLayer - backLayerNum) + '/' + url.TrimStart('.', '/');
            }

            // 直接以路径开头,等同于以./开头
            else
            {
                return current + '/' + url;
            }
        }
    }
}
