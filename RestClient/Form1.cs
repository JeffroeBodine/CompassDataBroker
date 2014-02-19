using System;
using System.IO;
using System.Text;
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
        private readonly Uri _baseUri = new Uri(@"http://localhost/Documents/Service.svc/");
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
                var ser = new DataContractJsonSerializer(typeof(TOutputType));
                return (TOutputType)ser.ReadObject(ms);
            }
        }

        private string SerializeObject<T>(T dataObject)
        {
            var ser = new DataContractJsonSerializer(typeof(T));
            var ms = new MemoryStream();

            ser.WriteObject(ms, dataObject);
            return Encoding.ASCII.GetString(ms.ToArray());
        }
    }
}
