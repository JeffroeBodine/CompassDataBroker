using System.IO;
using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public class PageData
    {
        [DataMember(Order = 1)]
        public string FileName { get; set; }
        [DataMember(Order = 2)]
        public string FileExtension { get; set; }
        [DataMember(Order = 3)]
        public string MimeType { get; set; }

        [DataMember(Order = 4)]
        public Stream Stream { get; set; }
        [DataMember(Order = 5)]
        public byte[] Bytes { get; set; }

        public PageData(string fileName, string fileExtension, string mimeType, Stream stream)
        {
            FileName = fileName;
            FileExtension = fileExtension;
            MimeType = mimeType;
            Stream = stream;
        }
        
        public PageData(string fileName, string fileExtension, string mimeType, byte[] bytes)
        {
            FileName = fileName;
            FileExtension = fileExtension;
            MimeType = mimeType;
            Bytes = bytes;
        }
    }
}
