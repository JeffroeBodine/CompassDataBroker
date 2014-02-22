using NUnit.Framework;

namespace CompassDataBroker.Tests
{
    [TestFixture]
    public class DocumentsTests
    {
        private DocumentsService _broker;

        [SetUp]
        public void BeforeEach()
        {
            _broker = new DocumentsService();
        }

        [Test]
        public void MyFirstTest()
        {
            Assert.True(true);
        }

        [Test]
        public void TestdocumentTypeGroupsReturnsData()
        {
            var documentTypeGroups = _broker.GetDocumentTypeGroups();

            Assert.NotNull(documentTypeGroups);
            Assert.AreEqual(3, documentTypeGroups.Count);
            Assert.AreEqual(1, documentTypeGroups[0].ID);
            Assert.AreEqual("First", documentTypeGroups[0].Name);
            Assert.AreEqual(3, documentTypeGroups[0].DocumentTypes.Count);
        }

        [Test]
        public void TestdocumentTypeGroupReturnsData()
        {
            var documentTypeGroup = _broker.GetDocumentTypeGroup("1");

            Assert.NotNull(documentTypeGroup);
            Assert.AreEqual(1, documentTypeGroup.ID);
            Assert.AreEqual("First", documentTypeGroup.Name);
            Assert.AreEqual(3, documentTypeGroup.DocumentTypes.Count);
        }

        [Test]
        public void TestdocumentTypesReturnsData()
        {
            var documentTypes = _broker.GetDocumentTypes();

            Assert.NotNull(documentTypes);
            Assert.AreEqual(3, documentTypes.Count);
            Assert.AreEqual(1, documentTypes[0].ID);
            Assert.AreEqual("First", documentTypes[0].Name);
        }

        [Test]
        public void TestdocumentTypeReturnsData()
        {
            var documentType = _broker.GetDocumentType("1");

            Assert.NotNull(documentType);
            Assert.AreEqual(1, documentType.ID);
            Assert.AreEqual("First", documentType.Name);
        }

    }
}
