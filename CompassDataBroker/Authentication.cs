using System;
using System.Security.Authentication;
using ObjectLibrary;

namespace CompassDataBroker
{
    public static class Authentication
    {
        public static string AuthenticateUser(string userName, string password)
        {
            var ex = new AuthenticationException("User name or password is invalid");
            var user = DAL.GetUserInformation(userName);

            if (user == null)
                throw ex;

            var passwordToVerify = Encryption.EncryptPassword(password, user.Salt);

            if (passwordToVerify != user.Password)
                throw ex;

            var session = GetUserSession(user.ID);

            return session.Name;
        }

        internal static Session GetUserSession(long userID)
        {
            var session = DAL.GetExistingUserSession(userID);

            if (session == null)
               session = GetNewSession(userID);
            else if (SessionExpired(session))
                session = UpdateExistingSession(session);

            return session;
        }

        internal static void DeleteUserSession(string sessionID)
        {
            DAL.DeleteSession(sessionID);
        }

        internal static bool SessionExpired(Session session)
        {
            return (session.CreateDate < DateTime.Now.AddHours(-1));
        }

        internal static Session GetNewSession(long userID)
        {
            var session = new Session(-1, Guid.NewGuid().ToString(), userID, DateTime.Now);
            return DAL.AddSession(session);
        }

        internal static Session UpdateExistingSession(Session session)
        {
            session.CreateDate = DateTime.Now;
            session.Name = Guid.NewGuid().ToString();

           return DAL.UpdateSession(session);
        }
    }
}