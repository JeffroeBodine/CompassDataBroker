using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public abstract class BaseObject
    {
        [DataMember(Order = 1)]
        public int ID { get; set; }
        [DataMember(Order = 2)]
        public string Name { get; set; }

        protected BaseObject()
        { 
        }

        protected BaseObject(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
