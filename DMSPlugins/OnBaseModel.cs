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

        private Unity.Application OBConnection(string serviceURL, string dataSource, string userName, SecureString password)
        {
            Unity.OnBaseAuthenticationProperties onBaseAuthProperties = Unity.Application.CreateOnBaseAuthenticationProperties(serviceURL, userName, password.Insecure(), dataSource);
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

                    if (udtg.DocumentTypes != null)
                    {
                        foreach (var udt in udtg.DocumentTypes)
                        {
                            if (dtg.DocumentTypes == null)
                                dtg.DocumentTypes = new DocumentTypes();

                            dtg.DocumentTypes.Add(new DocumentType(udt.ID, udt.Name));
                        }
                    }
                }
            }
            return documentTypes;
        }
    }
}
