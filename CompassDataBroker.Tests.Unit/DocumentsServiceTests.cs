﻿using System;
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
        public void TestDocumentTypeGroupsReturnsData()
        {
            var documentTypeGroups = _broker.GetDocumentTypeGroups();

            Assert.NotNull(documentTypeGroups);
            Assert.AreEqual(3, documentTypeGroups.Count);
            Assert.AreEqual("1", documentTypeGroups[0].ID);
            Assert.AreEqual("First", documentTypeGroups[0].Name);
            Assert.AreEqual(3, documentTypeGroups[0].DocumentTypes.Count);
        }

        [Test]
        public void TestDocumentTypeGroupReturnsData()
        {
            var documentTypeGroup = _broker.GetDocumentTypeGroup("1");

            Assert.NotNull(documentTypeGroup);
            Assert.AreEqual("1", documentTypeGroup.ID);
            Assert.AreEqual("First", documentTypeGroup.Name);
            Assert.AreEqual(3, documentTypeGroup.DocumentTypes.Count);
        }

        [Test]
        public void TestDocumentTypesReturnsData()
        {
            var documentTypes = _broker.GetDocumentTypes();

            Assert.NotNull(documentTypes);
            Assert.AreEqual(3, documentTypes.Count);
            Assert.AreEqual("1", documentTypes[0].ID);
            Assert.AreEqual("First", documentTypes[0].Name);
        }

        [Test]
        public void TestDocumentTypeReturnsData()
        {
            var documentType = _broker.GetDocumentType("1");

            Assert.NotNull(documentType);
            Assert.AreEqual("1", documentType.ID);
            Assert.AreEqual("First", documentType.Name);
        }

        [Test]
        public void TestKeywordTypesReturnsData()
        {
            var keywordTypes = _broker.GetKeywordTypes();

            Assert.NotNull(keywordTypes);
            Assert.AreEqual(3, keywordTypes.Count);
            Assert.AreEqual("1", keywordTypes[0].ID);
            Assert.AreEqual("First", keywordTypes[0].Name);
            Assert.AreEqual("System.String", keywordTypes[0].DataTypeString);
            Assert.AreEqual("", keywordTypes[0].DefaultValue);
        }

        [Test]
        public void TestKeywordTypeReturnsData()
        {
            var keywordType = _broker.GetKeywordType("1");

            Assert.NotNull(keywordType);
            Assert.AreEqual("1", keywordType.ID);
            Assert.AreEqual("First", keywordType.Name);
            Assert.AreEqual("System.String", keywordType.DataTypeString);
            Assert.AreEqual("", keywordType.DefaultValue);
        }

        [Test]
        public void TestGetDocument()
        {
            var document = _broker.GetDocument("1");

             Assert.NotNull(document);
             Assert.AreEqual("1", document.ID);
            Assert.AreEqual("First", document.Name);
            Assert.AreEqual(DateTime.Today, document.CreateDate);
            Assert.AreEqual(DateTime.Today, document.LUPDate);
            Assert.AreEqual("Me", document.Author);
            Assert.AreEqual(1, document.DocumentTypeID);
        }


    }
}