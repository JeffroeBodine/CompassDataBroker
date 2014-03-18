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
    public class db
    {
        public static User CreateUser(User newUser)
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

        public static string AuthenticateUser(string userName, string password)
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var u = session.CreateCriteria(typeof(User)).List<User>().Select(x => x.Name = userName);

                    transaction.Commit();
                }
            }

            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    var users = session.CreateCriteria(typeof(User))
                        .List<User>();

                    foreach (var user in users)
                    {
                        //Yay users.
                        int i = 0;
                    }
                }
            }

            return Guid.NewGuid().ToString();
        }

        public static User GetUserInformation(string userName)
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    var users = session.CreateCriteria(typeof(User)).List<User>();

                    foreach (var user in users)
                    {
                        if (string.Equals(user.Name, userName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            return user;
                        }
                    }
                }
            }
            return null;
        }

        public static Session GetExistingUserSession(long userID)
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    var userSessions = session.CreateCriteria(typeof(Session)).List<Session>();
                    return userSessions.FirstOrDefault(userSession => userSession.FkUser == userID);
                }
            }
        }

        public static Session AddSession(Session userSession)
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(userSession);
                    transaction.Commit();
                }
            }
            return userSession;
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

        public static long AddUser(User user)
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var dbUser = session.CreateCriteria(typeof(User)).List<User>().FirstOrDefault(x => String.Equals(x.Name, user.Name, StringComparison.CurrentCultureIgnoreCase));

                    if (dbUser == null)
                    {
                        session.Save(user);
                        transaction.Commit();
                    }
                    else
                    {
                        throw new DuplicateNameException(String.Format("User already exists with name {0}", user.Name));
                    }
                }
            }
            return user.ID;
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
              .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConnectionString))
              .Mappings(m =>m.FluentMappings.AddFromAssemblyOf<db>())
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
