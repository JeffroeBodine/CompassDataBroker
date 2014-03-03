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
    }
}
