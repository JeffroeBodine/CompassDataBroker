using System;
using System.IO;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace ObjectLibrary
{
    public class db
    {
        public const string DATABASE_FILE = @"c:\temp\CompassDataBroker.db";

        public static string AuthenticateUser(string userName, string password)
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var newUser = new User {ID = "1",  Name = "JeffroeBodine", Password = "encryptThis", Salt = "Salt"};

                    session.SaveOrUpdate(newUser);

                    transaction.Commit();
                }
            }

            using (var session = sessionFactory.OpenSession())
            {
                // retreive all stores and display them
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
                .Database(SQLiteConfiguration.Standard
                    .UsingFile(DATABASE_FILE))
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<db>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            if (File.Exists(DATABASE_FILE))
                File.Delete(DATABASE_FILE);

            new SchemaExport(config).Create(false, true);
        }
    }
}
