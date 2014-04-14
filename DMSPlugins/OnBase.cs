using ObjectLibrary.Collections;

namespace DMSPlugins
{
    public class OnBase
    {
        private const string SERVICE_URL = "http://vm-qatrunk-ob13/AppServer/Service.asmx";
        private const string DATASOURCE = "OBSERVER";

        private readonly OnBaseUnityModel _model;

        public OnBase(string userName, string password)
        {
            _model = new OnBaseUnityModel(SERVICE_URL,DATASOURCE, userName, password.Secure());
        }

        public  DocumentTypes GetDocumentTypes()
        {
            return _model.GetDocumentTypes();
        }
    }
}
