using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace CompassDataBroker
{
    [ServiceContract]
    public interface IAuthenticationService
    {
        [OperationContract]
        [Description("Authenticate User.")]
        [WebGet(UriTemplate = "AuthenticateUser/{username}/{password}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string AuthenticateUser(string username, string password);

    }
}
