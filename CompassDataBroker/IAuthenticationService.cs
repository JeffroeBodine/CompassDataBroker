using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;
using ObjectLibrary;

namespace CompassDataBroker
{
    [ServiceContract]
    public interface IAuthenticationService
    {
        [OperationContract]
        [Description("Authenticate User.")]
        [WebGet(UriTemplate = "AuthenticateUser/{username}/{password}",
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string AuthenticateUser(string username, string password);

        [OperationContract]
        [Description("Delete Session")]
        [WebInvoke(Method = "DELETE", UriTemplate = "Session/{sessionID}",
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        void DeleteSession(string sessionID);

        [OperationContract]
        [Description("Add a User.")]
        [WebInvoke(Method="POST", UriTemplate = "User", 
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        long AddUser(User user);

    }
}
