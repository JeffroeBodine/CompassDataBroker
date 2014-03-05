using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Linq;

namespace ObjectLibrary
{
    public class db
    {
        public static User CreateUser(User newUser)
        {
            newUser.Session = new Session(-1, Guid.NewGuid().ToString(), newUser.ID, DateTime.Now);
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
