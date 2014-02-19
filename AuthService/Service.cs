using System;

namespace AuthService
{
    public class Service : IService
    {
        public string AuthenticateUser(string username, string password)
        {
            return Guid.NewGuid().ToString();
        }
    }
}