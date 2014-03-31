using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ObjectLibrary
{
    public class Encryption
    {
        public static bool AuthenticateUser(string userName, string password)
        {
            const string databasePassword = "20fbe675a3d8556d675ef576c45962d5eecef3e2551145402eb530391edf825adde53a3cfde4d75ba077d63e45f784202a2084e44ea7e5a224d17e82983fd05c";
            const string databaseSalt = "JqRL4aEnRQhJ23k59FERDSS9gpGdwgNBWNsTmgvQ1Yvg/9zvoYLPgX4mfAzNa79PJIakH4WRU7DIbxA576bDPZOYiEoD67ppC6JjAgFxO5AlezuAnX8Crv0bMcyUBEfgrEDoX75B7+Erm5t2xP5dpCfq1jQgSeqxdKtnYL0nrGI=";

            if (databasePassword == EncryptPassword(password, databaseSalt))
                return true;

            return false;
        }

        public static string EncryptPassword(string password, string salt)
        {
            string valueToEncrypt = salt + password;

            var encryptedString = Sha512(valueToEncrypt);

            return encryptedString;
        }

        public static string EncryptPassword(string password)
        {
           return EncryptPassword(password, Salt(128));
        }

        private static string Sha512(string text)
        {
            var textBytes = new UnicodeEncoding().GetBytes(text);
            var hashValue = new SHA512Managed().ComputeHash(textBytes);

            return hashValue.Aggregate("", (current, x) => current + String.Format("{0:x2}", x));
        }

        public static string Salt(int length)
        {
            var salt = new byte[length];
            RandomNumberGenerator.Create().GetBytes(salt);
            return Convert.ToBase64String(salt);
        }
    }
}
