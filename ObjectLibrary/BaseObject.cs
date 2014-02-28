using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public abstract class BaseObject
    {
        [DataMember(Order = 1)]
        public virtual string ID { get; set; }
        [DataMember(Order = 2)]
        public virtual string Name { get; set; }

        protected BaseObject()
        { 
        }

        protected BaseObject(string id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
