using System;
using NUnit.Framework;

namespace CompassDataBroker.Tests
{
    [TestFixture]
    public class EncryptionTests
    {
        [Test]
        public void VerifyThatSaltIsLongEnough()
        {
            var salt = ObjectLibrary.Encryption.Csprng();
            Assert.AreEqual(172, salt.Length);
        }

        [Test]
        public void VerifyAuthentication()
        {
            var databaseSalt = "JqRL4aEnRQhJ23k59FERDSS9gpGdwgNBWNsTmgvQ1Yvg/9zvoYLPgX4mfAzNa79PJIakH4WRU7DIbxA576bDPZOYiEoD67ppC6JjAgFxO5AlezuAnX8Crv0bMcyUBEfgrEDoX75B7+Erm5t2xP5dpCfq1jQgSeqxdKtnYL0nrGI=";
            var databasePassword = "20fbe675a3d8556d675ef576c45962d5eecef3e2551145402eb530391edf825adde53a3cfde4d75ba077d63e45f784202a2084e44ea7e5a224d17e82983fd05c";
            var plainTextPasswrd = "bodine";

            var hash = ObjectLibrary.Encryption.EncryptPassword(plainTextPasswrd, databaseSalt);

            Assert.AreEqual(databasePassword, hash);
        }


    }
}
