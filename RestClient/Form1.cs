using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using ObjectLibrary;
using ObjectLibrary.Collections;

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

        private async void btnGetDocumentTypeGroups_Click(object sender, EventArgs e)
        {
            const string method = "DocumentTypeGroups/";
            var documentTypeGroups = await CallRestMethod<DocumentTypeGroups>(method);

            tbOutput.Text = SerializeObject(documentTypeGroups);
        }

        private async void btnGetDocumentTypeGroup_Click(object sender, EventArgs e)
        {
            const string method = "DocumentTypeGroups/1";
            var documentTypeGroup = await CallRestMethod<DocumentTypeGroup>(method);

            tbOutput.Text = SerializeObject(documentTypeGroup);
        }

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

            var response = (HttpWebResponse)request.GetResponse();
        }

        #endregion

        private async Task<TOutputType> CallRestMethod<TOutputType>(string method)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseUri;
                HttpResponseMessage response = await client.GetAsync(method);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseBody));
                var ser = new DataContractJsonSerializer(typeof (TOutputType));
                return (TOutputType) ser.ReadObject(ms);
            }
        }

        private string SerializeObject<T>(T dataObject)
        {
            var ser = new DataContractJsonSerializer(typeof (T));
            var ms = new MemoryStream();

            ser.WriteObject(ms, dataObject);
            return Encoding.ASCII.GetString(ms.ToArray());
        }   

    }
}