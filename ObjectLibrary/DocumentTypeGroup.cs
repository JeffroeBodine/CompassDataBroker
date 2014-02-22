using System.Runtime.Serialization;
using ObjectLibrary.Collections;

namespace ObjectLibrary
{
    [DataContract]
    public class DocumentTypeGroup : BaseObject
    {
        [DataMember(Order = 100)]
        public DocumentTypes DocumentTypes { get; set; }

        public DocumentTypeGroup(string id, string name, DocumentTypes documentTypes)
        {
            ID = id;
            Name = name;
            DocumentTypes = documentTypes;
        }
    }
}
