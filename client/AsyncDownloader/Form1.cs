using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AsyncDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string getExeFolder()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        }

        private void startDownload()
        {
            var uri = new Uri("http://localhost:3002/test1Mb.db");
            var fileName = Path.GetFileName(uri.LocalPath);
            var destinationPath = Path.Combine(getExeFolder(), fileName);

            WebClient client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            client.DownloadFileAsync(uri, destinationPath);
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            lblProgress.Text = "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive;
            progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            lblProgress.Text = "Completed";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startDownload();
        }
    }
}
