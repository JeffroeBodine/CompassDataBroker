using System;
using System.IO;
using System.ServiceModel.Activation;
using ObjectLibrary;
using ObjectLibrary.Collections;
using ObjectLibrary.SearchKeywords;

namespace CompassDataBroker
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : IDocumentsService, IAuthenticationService
    {
        private readonly string _imageStore = AppDomain.CurrentDomain.BaseDirectory + @"\ImageStore\";

        public DocumentTypes GetDocumentTypes()
        {
            return FakeData.DocumentTypes;
        }
        public DocumentType GetDocumentType(string id)
        {
            return FakeData.DocumentTypes.Find(x => x.ID == id);
        }

        public KeywordTypes GetKeywordTypes()
        {
            return FakeData.KeywordTypes;
        }
        public KeywordType GetKeywordType(string id)
        {
            return FakeData.KeywordTypes.Find(x => x.ID == id);
        }

        public Document GetDocument(string id)
        {
            return FakeData.Documents.Find(x => x.ID == id);
        }

        public PageData GetPageData(string documentID, string pageNumber)
        {
            return FakeData.PageData;
        }

        public bool UpdatePage(string documentID, string pageNumber, Stream imageStream)
        {
            throw new NotImplementedException();
        }

        public Documents GetDocuments(SearchCriteria searchCriteria)
        {
            foreach (var criteria in searchCriteria)
            {
                if (criteria.GetType() == typeof(CreateDateTimeRangeSearchKeyword))
                {

                }
                else if (criteria.GetType() == typeof(DateTimeRangeSearchKeyword))
                {

                }
                else if (criteria.GetType() == typeof(DocumentTypeSearchKeyword))
                {

                }
                else if (criteria.GetType() == typeof(KeywordSearchKeyword))
                {

                }
                else
                {
                    throw new NotSupportedException();
                }


            }
            return FakeData.Documents;
        }

        public bool DeleteDocument(string id)
        {
            return true;
        }

        public bool UpdateKeywords(string documentID, Keywords keywords)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDocumentType(string documentID, string documentTypeID)
        {
            throw new NotImplementedException();
        }

        public Keywords GetDocumentKeywords(string documentID)
        {
            throw new NotImplementedException();
        }

        public bool DeletePage(string documentID, string pageNumber)
        {
            throw new NotImplementedException();
        }

        public bool InsertPage(string documentID, string pageNumber, Stream imageStream)
        {
            throw new NotImplementedException();
        }

        public Stream Download(string fileName)
        {
            var absolutePath = _imageStore + fileName;
            if (!File.Exists(absolutePath))
                throw new FileLoadException("File Not Found");
            return new FileStream(_imageStore + fileName, FileMode.Open, FileAccess.Read);
        }

        public void Upload(Stream stream, string fileName)
        {
            if (!Directory.Exists(_imageStore))
                Directory.CreateDirectory(_imageStore);

            //TODO: Check if file already exists first.

            using (var fs = new FileStream(_imageStore + fileName, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fs);
                stream.Close();
            }
        }

        public string AuthenticateUser(string username, string password)
        {
            return Guid.NewGuid().ToString();
        }
    }
}