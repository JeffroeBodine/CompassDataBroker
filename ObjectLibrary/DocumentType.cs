using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public class DocumentType : BaseObject
    {
        public DocumentType(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
