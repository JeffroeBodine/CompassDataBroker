using System;
using NUnit.Framework;
using ObjectLibrary;
using Moq;

namespace CompassDataBroker.Tests
{
    [TestFixture]
    public class DocumentsTests
    {
        private Service _broker;
        private Mock<DAL> _db;

        [SetUp]
        public void BeforeEach()
        {
            _db = new Mock<DAL>();
            _broker = new Service(_db.Object);
        }

        [Test]
        public void MyFirstTest()
        {
            Assert.True(true);
        }

        [Test]
        public void TestDocumentTypesReturnsData()
        {
            var documentTypes = _broker.GetDocumentTypes();

            Assert.NotNull(documentTypes);
            Assert.AreEqual(3, documentTypes.Count);
            Assert.AreEqual(1, documentTypes[0].ID);
            Assert.AreEqual("First", documentTypes[0].Name);
        }

        [Test]
        public void TestDocumentTypeReturnsData()
        {
            var documentType = _broker.GetDocumentType("1");

            Assert.NotNull(documentType);
            Assert.AreEqual(1, documentType.ID);
            Assert.AreEqual("First", documentType.Name);
        }

        [Test]
        public void TestKeywordTypesReturnsData()
        {
            var keywordTypes = _broker.GetKeywordTypes();

            Assert.NotNull(keywordTypes);
            Assert.AreEqual(3, keywordTypes.Count);
            Assert.AreEqual(1, keywordTypes[0].ID);
            Assert.AreEqual("First", keywordTypes[0].Name);
            Assert.AreEqual("System.String", keywordTypes[0].DataTypeString);
            Assert.AreEqual("", keywordTypes[0].DefaultValue);
        }

        [Test]
        public void TestKeywordTypeReturnsData()
        {
            var keywordType = _broker.GetKeywordType("1");

            Assert.NotNull(keywordType);
            Assert.AreEqual(1, keywordType.ID);
            Assert.AreEqual("First", keywordType.Name);
            Assert.AreEqual("System.String", keywordType.DataTypeString);
            Assert.AreEqual("", keywordType.DefaultValue);
        }

        [Test]
        public void TestGetDocument()
        {
            var document = _broker.GetDocument("1");

             Assert.NotNull(document);
             Assert.AreEqual(1, document.ID);
            Assert.AreEqual("First", document.Name);
            Assert.AreEqual(DateTime.Today, document.CreateDate);
            Assert.AreEqual(DateTime.Today, document.LUPDate);
            Assert.AreEqual("Me", document.Author);
            Assert.AreEqual(1, document.DocumentTypeID);
        }

        [Test]
        public void TestDeleteDocument()
        {
            var success = _broker.DeleteDocument("1");

            Assert.True(success);
        }

        [Test]
        public void TestAddUser()
        {
            long expected = 111;
            _db.Setup(x => x.AddUser(It.IsAny<User>())).Returns(expected);

            var newUser = new User(-1, "tUser", "password", "tUser@gmail.com", "test", "user");
            var actual = _broker.AddUser(newUser);

            Assert.AreEqual(expected,actual);
            _db.Verify(foo => foo.AddUser(newUser), Times.Once);

        }

    }
}
