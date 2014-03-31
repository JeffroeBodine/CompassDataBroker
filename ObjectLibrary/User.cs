using System.Runtime.Serialization;
using FluentNHibernate.Mapping;

namespace ObjectLibrary
{
    [DataContract]
    public class User : BaseObject
    {
        [DataMember(Order = 100)]
        public string Password { get; set; }

        public string Salt { get; set; }
        [DataMember(Order = 102)]
        public string EMail { get; set; }
        [DataMember(Order = 103)]
        public string FirstName { get; set; }
        [DataMember(Order = 104)]
        public string LastName { get; set; }
      
        public User()
        {
        }

        public User(long id, string name, string password, string eMail, string firstName, string lastName): base(id, name)
        {
            Password = password;
            EMail = eMail;
            FirstName = firstName;
            LastName = lastName;
        }

        public User(long id, string name, string password, string eMail, string firstName, string lastName, string salt): this(id, name,password, eMail, firstName, lastName)
        {
            Salt = salt;
        }

        public class Map : ClassMap<User>
        {
            public Map()
            {
                Id(x => x.ID).Column("ID").GeneratedBy.Identity();
                Map(x => x.Name);
                Map(x => x.Password);
                Map(x => x.Salt);
                Map(x => x.EMail);
                Map(x => x.FirstName);
                Map(x => x.LastName);
               
            }
        }
    }

   
}
