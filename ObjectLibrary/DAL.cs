﻿using System;
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

        public virtual List<T> GetAll<T>(T obj)
        {
            using (var session = CreateSessionFactory().OpenSession())
            {
                return session.Query<T>().ToList();
            }
        }

        public virtual BaseObject GetSingle(long id)
        {
            using (var session = CreateSessionFactory().OpenSession())
            {
                return session.Query<BaseObject>().FirstOrDefault(x => x.ID == id);
            }
        }

        public virtual BaseObject GetSingle(string name)
        {
            using (var session = CreateSessionFactory().OpenSession())
            {
                return session.Query<BaseObject>().FirstOrDefault(x => x.Name == name);
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
            using (var session = CreateSessionFactory().OpenSession())
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
