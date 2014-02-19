using System.Linq;
using Hyland.Unity;
using System.Security;
using ObjectLibrary.Collections;
using lib = ObjectLibrary;
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

        public Application OBConnection(string serviceURL, string dataSource, string userName, SecureString password)
        {
            OnBaseAuthenticationProperties onBaseAuthProperties =
                Application.CreateOnBaseAuthenticationProperties(serviceURL, userName, password.ToString(), dataSource);
            return Application.Connect(onBaseAuthProperties);
        }

        public DocumentTypeGroups GetDocumentTypeGroups()
        {
            var documentTypeGroups = new DocumentTypeGroups();
            using (Application app = OBConnection(ServiceUrl, DataSource, UserName, Password))
            {
                documentTypeGroups.AddRange(app.Core.DocumentTypeGroups.Select(dtg => new lib.DocumentTypeGroup((int) dtg.ID, dtg.Name, null)));
            }
            return documentTypeGroups;
        }
    }
}
