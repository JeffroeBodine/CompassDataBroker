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
        [DataMember(Order = 104)]
        public Keywords Keywords { get; set; }

        public Document(int id, string name, DateTime createDate, DateTime lupDate, string author, int documentTypeID, Keywords keywords)
        {
            ID = id;
            Name = name;

            CreateDate = createDate;
            LUPDate = lupDate;
            Author = author;
            DocumentTypeID = documentTypeID;
            Keywords = keywords;
        }
    }
}
