using NUnit.Framework;
using ObjectLibrary;
using Moq;
using Should.Fluent;
using System;

namespace CompassDataBroker.Tests
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private Authentication _auth;
        private Mock<DAL> _db;

        [SetUp]
        public void BeforeEach()
        {
            _db = new Mock<DAL>();
            _auth = new Authentication(_db.Object);
        }

        [Test]
        public void MyFirstTest()
        {
            Assert.True(true);
        }

        [Test]
        public void TestAuthenticateUser()
        {
            var salt = "w2bWxJv9wmjyNp+NGUqtC6H/Ew2vscSNPuYNxxFP692oaYInrfEm1s4N0xXhYWvNukNTOo2iFHPxpp7a3uo+OLbaeDWPgYcfqaErkXK8tm6O4ocyJQ1qkEeX/9grw8e2xSiN+Mne+ispyU3P3o1yQneoXdyrVJ/G/DTb4xffMuI=";
            var encryptedPassword ="cd7c64ea92525b9d8c9b28cf34ab9a46b2532ab1cffe0abd2868f95b9b30b94bde694edda698d75fd6909aa10c486d6d81f9348d327437182aa7557b4542f7d7";
            var mockedUser = new User(1, "testUser", encryptedPassword, "testUser@gmail.com", "test", "user", salt);

            var mockedSession = new Session(1, "4BB75EF2-1306-4C50-886A-AF79C9CEE2F4", 1, DateTime.Now);

            _db.Setup(x => x.GetUserInformation(It.IsAny<string>())).Returns(mockedUser);
            _db.Setup(x => x.GetExistingUserSession(1)).Returns(mockedSession);

            var actualSessionToken = _auth.AuthenticateUser("testUser", "P@55w0rd");

            actualSessionToken.Should().Not.Be.NullOrEmpty();
        }

    }
}
