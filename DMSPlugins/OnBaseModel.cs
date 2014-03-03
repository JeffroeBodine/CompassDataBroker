using System.Linq;
using Unity = Hyland.Unity;
using System.Security;
using ObjectLibrary;
using ObjectLibrary.Collections;

namespace DMSPlugins
{
    public class OnBaseUnityModel
    {
        private string ServiceUrl { get; set; }
        private string DataSource { get; set; }
        private string UserName { get; set; }
        private SecureString Password { get; set; }

        public OnBaseUnityModel(string serviceURL, string dataSource, string userName, SecureString password)
        {
            ServiceUrl = serviceURL;
            DataSource = dataSource;
            UserName = userName;
            Password = password;
        }

        public Unity.Application OBConnection(string serviceURL, string dataSource, string userName, SecureString password)
        {
            Unity.OnBaseAuthenticationProperties onBaseAuthProperties =
                Unity.Application.CreateOnBaseAuthenticationProperties(serviceURL, userName, password.ToString(), dataSource);
            return Unity.Application.Connect(onBaseAuthProperties);
        }

        public DocumentTypes GetDocumentTypes()
        {
            var documentTypes = new DocumentTypes();
            using (var app = OBConnection(ServiceUrl, DataSource, UserName, Password))
            {
                foreach (var udtg in app.Core.DocumentTypeGroups)
                {
                    var dtg = new DocumentType(udtg.ID, udtg.Name);
                    documentTypes.Add(dtg);

                    dtg.DocumentTypes.AddRange(app.Core.DocumentTypeGroups.Select(udt => new DocumentType(udt.ID, udt.Name)));
                }
            }
            return documentTypes;
        }
    }
}
