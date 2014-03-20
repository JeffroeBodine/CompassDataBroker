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
        [WebGet(UriTemplate = "AuthenticateUser/{username}/{password}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string AuthenticateUser(string username, string password);

        [OperationContract]
        [Description("Create fake User.")]
        [WebGet(UriTemplate = "CreateFakeUser", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        User CreateFakeUser();

        [OperationContract]
        [Description("Add a User.")]
        [WebInvoke(Method="POST", UriTemplate = "User", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        long AddUser(User user);

        [OperationContract]
        [Description("String test")]
        [WebInvoke(Method = "POST", UriTemplate = "String", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string StringTest(string s);

        [OperationContract]
        [Description("Throw Exception")]
        [WebGet(UriTemplate = "ThrowException", ResponseFormat = WebMessageFormat.Json,RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        void ThrowException();
    }
}
