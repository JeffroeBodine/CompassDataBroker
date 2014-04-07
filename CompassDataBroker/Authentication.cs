using System;
using System.Security.Authentication;
using ObjectLibrary;

namespace CompassDataBroker
{
    public class Authentication
    {
        private readonly DAL _db;
        private AuthenticationException authException;
        public Authentication(DAL db)
        {
            _db = db;
            authException = new AuthenticationException("User name or password is invalid");
        }

        public string AuthenticateUser(string userName, string password)
        {
           
            var user = _db.GetUser(userName);

            if (user == null)
                throw authException;

            var passwordToVerify = Encryption.EncryptPassword(password, user.Salt);

            if (passwordToVerify != user.Password)
                throw authException;

            var session = GetUserSession(user.ID);

            return session.Name;
        }

        public Session GetUserSession(long userID)
        {
            var session = _db.GetExistingUserSession(userID);

            if (session == null)
               session = GetNewSession(userID);
            else if (SessionExpired(session))
                session = UpdateExistingSession(session);

            return session;
        }

        public void DeleteUserSession(string sessionID)
        {
            _db.DeleteSession(sessionID);
        }

        public bool SessionExpired(Session session)
        {
            return (session.CreateDate < DateTime.Now.AddHours(-1));
        }

        public Session GetNewSession(long userID)
        {
            var session = new Session(-1, Guid.NewGuid().ToString(), userID, DateTime.Now);
            return _db.AddSession(session);
        }

        public Session UpdateExistingSession(Session session)
        {
            session.CreateDate = DateTime.Now;
            session.Name = Guid.NewGuid().ToString();

           return _db.UpdateSession(session);
        }
    }
}