using System.Runtime.Serialization;
using ObjectLibrary.Collections;

namespace ObjectLibrary
{
    [DataContract]
    public class DocumentType : BaseObject
    {
        [DataMember]
        public DocumentTypes DocumentTypes { get; set; }

        public DocumentType(string id, string name)
        {
            ID = id;
            Name = name;
        }

        public DocumentType(string id, string name, DocumentTypes documentTypes) : base(id, name)
        {
            DocumentTypes = documentTypes;
        }
    }
}
