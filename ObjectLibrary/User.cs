using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public class User :BaseObject
    {
        [DataMember(Order = 100)]
        public virtual string Password { get; set; }
        [DataMember(Order = 101)]
        public virtual string Salt { get; set; }

        public User()
        {
        }

        public User(string id, string name, string password, string salt)
        {
            ID = id;
            Name = name;
            Password = password;
            Salt = salt;
        }
    }
}
