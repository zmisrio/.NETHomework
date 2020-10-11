using System;
using System.Threading;
using System.Windows.Forms;

namespace SimpleCrawler
{
    public partial class MainForm : Form
    {
        Crawler crawler = new Crawler();

        Thread crawelThread;

        private void AddUrl(string url)
        {
            urlListBox.Items.Add(url);
        }

        private void Crawler_PageDownloaded(string url)
        {
            if (this.urlListBox.InvokeRequired)
            {
                Action<String> action = this.AddUrl;
                this.Invoke(action, new object[] { url });
            }
            else
            {
                AddUrl(url);
            }
        }

        private void AddErrorMessage(string message)
        {
            messageListBox.Items.Add(message);
        }

        private void Crawler_Error(string message)
        {
            if (this.messageListBox.InvokeRequired)
            {
                Action<string> action = this.AddErrorMessage;
                this.Invoke(action, new object[] { message });
            }
            else
            {
                AddErrorMessage(message);
            }
        }

        public MainForm()
        {
            InitializeComponent();
            crawler.PageDownloaded += Crawler_PageDownloaded;
            crawler.PageDownloadMessage += Crawler_Error;

            crawelThread = new Thread(crawler.Crawl);
        }

        private void crawlButton_Click(object sender, EventArgs e)
        {
            crawler.AddStartUrl(txtStartUrl.Text);

            urlListBox.Items.Clear();
            messageListBox.Items.Clear();

            messageListBox.Items.Add("开始爬取。");
            crawler.sw.Start();

            crawelThread = new Thread(crawler.Crawl);
            crawelThread.IsBackground = true;

            crawelThread.Start();
        }
    }
}
