using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Linq;
using ObjectLibrary.Collections;

namespace ObjectLibrary
{
    public class DAL
    {
        public virtual User CreateUser(User newUser)
        {
            newUser.Salt = Encryption.Salt(128);

            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(newUser);
                    session.Save(new Session(-1, Guid.NewGuid().ToString(), newUser.ID, DateTime.Now));
                    transaction.Commit();
                }
            }
            return newUser;
        }

        public static User GetUserInformation(string userName)
        {
            using (var session = CreateSessionFactory().OpenSession())
            {
                using (session.BeginTransaction())
                {
                   return session.Query<User>().FirstOrDefault(x => x.Name == userName);
                }
            }
        }

        public static Session GetExistingUserSession(long userID)
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    return session.Query<Session>().FirstOrDefault(x => x.FkUser == userID);
                }
            }
        }

        public static Session AddSession(Session userSession)
        {
            using (var session = CreateSessionFactory().OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(userSession);
                    transaction.Commit();
                }
            }
            return userSession;
        }

        public static void DeleteSession(string sessionID)
        {
            using (var session = CreateSessionFactory().OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var existingSession = session.Query<Session>().FirstOrDefault(x => x.Name == sessionID);

                    if (existingSession != null)
                        session.Delete(existingSession);
                        transaction.Commit();
                }
            }
        }

        public static Session UpdateSession(Session userSession)
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(userSession);
                    transaction.Commit();
                }
            }
            return userSession;
        }

        public virtual long AddUser(User user)
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var existingUser = session.Query<User>().FirstOrDefault(x => String.Equals(x.Name, user.Name, StringComparison.CurrentCultureIgnoreCase));
                  
                    if (existingUser != null)
                        throw new DuplicateNameException(String.Format("User already exists with name {0}", user.Name));

                    session.Save(user);
                    transaction.Commit();
                }
            }
            return user.ID;
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
              .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConnectionString))
              .Mappings(m =>m.FluentMappings.AddFromAssemblyOf<DAL>())
              .BuildSessionFactory();
        }

        private static string ConnectionString
        {
            get {
                var csb = new SqlConnectionStringBuilder
                    {
                        DataSource = @".\",
                        InitialCatalog = "CompassDataBroker",
                        UserID = "sa",
                        Password = "northwoods",
                        PersistSecurityInfo = false
                    };

                return csb.ToString();
            }
        }

    }
}
