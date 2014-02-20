using System.ComponentModel;
using System.IO;
using ObjectLibrary;
using System.ServiceModel;
using System.ServiceModel.Web;
using ObjectLibrary.Collections;

namespace CompassDataBroker
{
    [ServiceContract]
    public interface IDocumentsService
    {

        #region Reference Object Methods
        [OperationContract]
        [Description("Get document type groups.")]
        [WebGet(UriTemplate = "DocumentTypeGroups/", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        DocumentTypeGroups GetDocumentTypeGroups();

        [OperationContract]
        [Description("Get document type group based on ID.")]
        [WebGet(UriTemplate = "DocumentTypeGroups/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        DocumentTypeGroup GetDocumentTypeGroup(string id);

        [OperationContract]
        [Description("Get document types.")]
        [WebGet(UriTemplate = "DocumentTypes/", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        DocumentTypes GetDocumentTypes();

        [OperationContract]
        [Description("Get document type based on ID.")]
        [WebGet(UriTemplate = "DocumentTypes/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        DocumentType GetDocumentType(string id);

        [OperationContract]
        [Description("Get keyword types.")]
        [WebGet(UriTemplate = "KeywordTypes/", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        KeywordTypes GetKeywordTypes();

        [OperationContract]
        [Description("Get keyword types based on ID.")]
        [WebGet(UriTemplate = "KeywordTypes/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        KeywordType GetKeywordType(string id);
        #endregion

        #region Documents
        [OperationContract]
        [Description("Get document based on ID.")]
        [WebGet(UriTemplate = "Document/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Document GetDocument(string id);

        [OperationContract]
        [Description("Create document.")]
        [WebInvoke(Method="Post", UriTemplate = "Document/", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int CreateDocument(Document document);

        [OperationContract]
        [Description("Delete document based on ID.")]
        [WebInvoke(Method="Delete", UriTemplate = "Document/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Document DeleteDocument(string id);

        [OperationContract]
        [Description("Update document keywords based on ID.")]
        [WebInvoke(Method = "Put", UriTemplate = "UpdateKeywords/{documentID}/", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool UpdateKeywords(string documentID, Keywords keywords);

        [OperationContract]
        [Description("Update document type based on ID.")]
        [WebInvoke(Method = "Put", UriTemplate = "UpdateDocumentType/{documentID}/{documentTypeID}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool UpdateDocumentType(string documentID, string documentTypeID);

        [OperationContract]
        [Description("Get document keywords based on ID.")]
        [WebGet(UriTemplate = "DocumentKeywords/{documentID}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Keywords GetDocumentKeywords(string documentID);
        #endregion

        #region Page
        [OperationContract]
        [Description("Get page based on document ID and page number.")]
        [WebGet(UriTemplate = "Page/{documentID}/{pageNumber}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        PageData Get(string documentID, string pageNumber);

        [OperationContract]
        [Description("Delete page based on document ID and page number.")]
        [WebInvoke(Method = "Delete", UriTemplate = "Page/{documentID}/{pageNumber}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool DeletePage(string documentID, string pageNumber);

        [OperationContract]
        [Description("Insert page based on document ID and page number.")]
        [WebInvoke(Method = "Post", UriTemplate = "Page/{documentID}/{pageNumber}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool InsertPage(string documentID, string pageNumber, Stream imageStream);

        [OperationContract]
        [Description("Update page based on document ID and page number.")]
        [WebInvoke(Method = "Put", UriTemplate = "Page/{documentID}/{pageNumber}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool UpdatePage(string documentID, string pageNumber, Stream imageStream);
        #endregion

        [OperationContract]
        [Description("Document search.")]
        [WebInvoke(UriTemplate = "DocumentSearch/", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Documents GetDocuments(SearchCriteria searchCriteria);

        [OperationContract]
        [Description("Stream.")]
        [WebGet(UriTemplate = "Stream/", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Stream GetStream();

        [OperationContract]
        [Description("Stream.")]
        [WebInvoke(Method = "POST", UriTemplate = "Stream/", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool PutStream(Stream stream);
    }
}
