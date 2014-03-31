using System;
using NUnit.Framework;
using ObjectLibrary;
using Moq;
using NUnit.Framework;
using Should.Fluent;

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
        [Ignore]//Need to fix this test with actual auth methods
        public void TestAuthenticateUser()
        {
            var mockedUser = new User(1, "testUser", "P@55w0rd", "testUser@gmail.com", "test", "user");
            _db.Setup(x => x.GetUserInformation(It.IsAny<string>())).Returns(mockedUser);

            var actualSessionToken = _auth.AuthenticateUser("testUser", "testPassword");

            actualSessionToken.Should().Not.Be.NullOrEmpty();
        }

    }
}
