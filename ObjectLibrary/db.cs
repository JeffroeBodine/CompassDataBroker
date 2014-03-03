using System;
using System.Data.SqlClient;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

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
                    var newUser = new User {Name="JeffroeBodine", Password="encryptThis", EMail="jturner@sparkoverflow.com"};

                    session.SaveOrUpdate(newUser);

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
