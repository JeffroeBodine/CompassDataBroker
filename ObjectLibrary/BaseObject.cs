using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public abstract class BaseObject
    {
        [DataMember(Order = 1)]
        public long ID { get; set; }
        [DataMember(Order = 2)]
        public string Name { get; set; }

        protected BaseObject()
        { 
        }

        protected BaseObject(long id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
