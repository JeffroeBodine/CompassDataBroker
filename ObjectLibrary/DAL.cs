using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Linq;

namespace ObjectLibrary
{
    public class DAL
    {

        #region CRUD
        public virtual T Add<T>(T obj)
        {
            using (var session = CreateSessionFactory().OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(obj);
                    transaction.Commit();
                }
            }
            return obj;
        }

        public virtual List<T> Get<T>()
        {
            using (var session = CreateSessionFactory().OpenSession())
            {
                return session.Query<T>().ToList();
            }
        }

        public virtual List<BaseObject> Get(long id)
        {
            using (var session = CreateSessionFactory().OpenSession())
            {
                return session.Query<BaseObject>().Where(x => x.ID == id).ToList();
            }
        }

        public virtual List<BaseObject> Get<T>(string name)
        {
            return Get<T>(name, true);
        }

        public virtual List<BaseObject> Get<T>(string name, bool caseSensitive)
        {
            using (var session = CreateSessionFactory().OpenSession())
            {
                return caseSensitive ? 
                    session.Query<BaseObject>().Where(x => x.Name == name).ToList() : 
                    session.Query<BaseObject>().Where(x => x.Name.ToUpper() == name.ToUpper()).ToList();
            }
        }

        public virtual T Update<T>(T obj)
        {
            using (var session = CreateSessionFactory().OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(obj);
                    transaction.Commit();
                }
            }
            return obj;
        }

        public virtual T Delete<T>(T obj)
        {
            using (var session = CreateSessionFactory().OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var existingObject = session.Query<T>().FirstOrDefault(x => x.Equals(obj));

                    if (existingObject != null)
                        session.Delete(existingObject);
                    transaction.Commit();
                }
            }
            return obj;
        }

        #endregion

        public virtual User CreateUser(User newUser)
        {
            var dbUser = Add(newUser);
            var dbSession = Add(new Session(-1, Guid.NewGuid().ToString(), dbUser.ID, DateTime.Now));

            //using (var session = CreateSessionFactory().OpenSession())
            //{
            //    using (var transaction = session.BeginTransaction())
            //    {
            //        session.Save(newUser);
            //        session.Save(new Session(-1, Guid.NewGuid().ToString(), newUser.ID, DateTime.Now));
            //        transaction.Commit();
            //    }
            //}
            return newUser;
        }

        public virtual User GetUserInformation(string userName)
        {
            using (var session = CreateSessionFactory().OpenSession())
            {
                using (session.BeginTransaction())
                {
                    return session.Query<User>().FirstOrDefault(x => x.Name == userName);
                }
            }
        }

        public virtual Session GetExistingUserSession(long userID)
        {
            using (var session = CreateSessionFactory().OpenSession())
            {
                using (session.BeginTransaction())
                {
                    return session.Query<Session>().FirstOrDefault(x => x.FkUser == userID);
                }
            }
        }

        public virtual Session AddSession(Session userSession)
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

        public virtual void DeleteSession(string sessionID)
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

        public virtual Session UpdateSession(Session userSession)
        {
            using (var session = CreateSessionFactory().OpenSession())
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
            if (Get<User>(user.Name, false).Any())
                throw new DuplicateNameException(String.Format("User already exists with name {0}", user.Name));

           return Add(user).ID;
        }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
              .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConnectionString))
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DAL>())
              .BuildSessionFactory();
        }

        private string ConnectionString
        {
            get
            {
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
