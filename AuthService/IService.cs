using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace AuthService
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [Description("Authenticate User.")]
        [WebGet(UriTemplate = "AuthenticateUser/{username}/{password}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string AuthenticateUser(string username, string password);

    }
}
