using System;
using System.Runtime.Serialization;
using ObjectLibrary.Collections;

namespace ObjectLibrary
{
    [DataContract]
    public class Document : BaseObject
    {
        [DataMember(Order = 100)]
        public DateTime CreateDate { get; set; }
        [DataMember(Order = 101)]
        public DateTime LUPDate { get; set; }
        [DataMember(Order = 102)]
        public string Author { get; set; }
        [DataMember(Order = 103)]
        public int DocumentTypeID { get; set; }

        public Document(string id, string name, DateTime createDate, DateTime lupDate, string author, int documentTypeID)
        {
            ID = id;
            Name = name;

            CreateDate = createDate;
            LUPDate = lupDate;
            Author = author;
            DocumentTypeID = documentTypeID;
           }
    }
}
