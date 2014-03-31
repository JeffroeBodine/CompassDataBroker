using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Threading;
using System.Windows.Forms;
using System.Net.Http;

namespace RestClient
{
    public partial class Form1 : Form
    {
        #region Class Level Vars

        private readonly Uri _baseUri = new Uri(@"http://localhost/CompassDataBroker/");

        #endregion

        #region Constructor

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Events

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (pbImage.Image != null)
                pbImage.Image.Dispose();
            pbImage.Image = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseUri;
                client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
                
                var stream = client.GetStreamAsync(@"Download\" + tbDownload.Text ).Result;

                using (Stream file = File.Create(@"c:\users\jturner\desktop\" + tbDownload.Text))
                {
                    stream.CopyTo(file);
                }
            }
            pbImage.Image = Image.FromFile(@"c:\users\jturner\desktop\" + tbDownload.Text);

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            const string url = "http://localhost/CompassDataBroker/Upload/";
            var fileName = Guid.NewGuid().ToString() + ".jpg";
            var request = (HttpWebRequest)WebRequest.Create(url + fileName);

            request.Method = "POST";
            request.SendChunked = true;
            request.AllowWriteStreamBuffering = false;
            request.ContentType = MediaTypeNames.Application.Octet;

            using (var inputStream = new FileStream(tbUpload.Text, FileMode.Open, FileAccess.Read))
            {
                inputStream.CopyTo(request.GetRequestStream());
            }

            request.GetResponse();
        }

        #endregion
    }
}