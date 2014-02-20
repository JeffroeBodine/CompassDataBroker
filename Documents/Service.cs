﻿using System;
using System.IO;
using System.ServiceModel.Activation;
using ObjectLibrary;
using ObjectLibrary.Collections;
using ObjectLibrary.SearchKeywords;

namespace DocumentsService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : IService
    {
        public DocumentTypeGroups GetDocumentTypeGroups()
        {
            return FakeData.DocumentTypeGroups;
        }
        public DocumentTypeGroup GetDocumentTypeGroup(string id)
        {
            return FakeData.DocumentTypeGroups.Find(x => x.ID == int.Parse(id));
        }

        public DocumentTypes GetDocumentTypes()
        {
            return FakeData.DocumentTypes;
        }
        public DocumentType GetDocumentType(string id)
        {
            return FakeData.DocumentTypes.Find(x => x.ID == int.Parse(id));
        }

        public KeywordTypes GetKeywordTypes()
        {
            return FakeData.KeywordTypes;
        }
        public KeywordType GetKeywordType(string id)
        {
            return FakeData.KeywordTypes.Find(x => x.ID == int.Parse(id));
        }

        public Document GetDocument(string id)
        {
            return FakeData.Documents.Find(x => x.ID == int.Parse(id));
        }

        public byte[] GetPageDataBytes()
        {
            return FakeData.PageDataBytes;
        }
        public Stream GetPageDataStream()
        {
            return FakeData.PageDataStream;
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

        public int CreateDocument(Document document)
        {
            throw new NotImplementedException();
        }

        public Document DeleteDocument(string id)
        {
            throw new NotImplementedException();
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

        public PageData Get(string documentID, string pageNumber)
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



        public Stream GetStream()
        {
            return FakeData.PageDataStream;
        }


    }
}