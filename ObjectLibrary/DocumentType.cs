using System.Runtime.Serialization;
using ObjectLibrary.Collections;

namespace ObjectLibrary
{
    [DataContract]
    public class DocumentType : BaseObject
    {
        public DocumentTypes DocumentTypes { get; set; }

        public DocumentType(string id, string name, DocumentTypes documentTypes)
        {
            ID = id;
            Name = name;
            DocumentTypes = documentTypes;
        }
    }
}
