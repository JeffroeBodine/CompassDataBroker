using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using ObjectLibrary.Collections;

namespace ObjectLibrary
{
    public class FakeData
    {
        public static DocumentTypes DocumentTypes
        {
            get
            {

                var documentTypechilderen = new DocumentTypes {new DocumentType(11, "Child", null)};

                var documentTypes = new DocumentTypes
                    {
                        new DocumentType(1, "First", documentTypechilderen),
                        new DocumentType(2, "Second", null),
                        new DocumentType(3, "third", null)
                    };
                return documentTypes;
            }
        }

        public static KeywordTypes KeywordTypes
        {
            get
            {
                var keywordTypes = new KeywordTypes
                    {
                        new KeywordType(1, "First", typeof (String), ""),
                        new KeywordType(2, "Second", typeof (String), ""),
                        new KeywordType(3, "Third", typeof (String), "")
                    };
                return keywordTypes;
            }
        }

        public static Documents Documents
        {
            get
            {
                var documents = new Documents
                    {
                        new Document(1, "First", DateTime.Today, DateTime.Today, "Me", 1),
                        new Document(2, "Second", DateTime.Today, DateTime.Today, "Me", 1),
                        new Document(3, "Third", DateTime.Today, DateTime.Today, "Me", 1)
                    };
                return documents;
            }
        }

        public static PageData PageData
        {
            get
            {
                return new PageData("1040.jpg", "jpeg", "image/jpg", new FileStream(@"c:\users\jturner\desktop\1040.jpg", FileMode.Open, FileAccess.Read));
            }
        }

        public static byte[] PageDataBytes
        {
            get
            {
                var ms = new MemoryStream();
                Properties.Resources._1040.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        public static Stream PageDataStream
        {
            get
            {

                var fs = new FileStream(@"c:\users\jturner\desktop\1040.jpg", FileMode.Open, FileAccess.Read);
                return fs;
            }
        }

        public static Stream ThumbnailDataStream
        {
            get
            {
                const string inputFileName = @"c:\users\jturner\desktop\1040.jpg";
                const string outputFileName = @"C:\GIT\DocumentsService\Documents\ImageStore\1040_thumb.jpg";

                const int desiredWidth = 128;
                const int desiredHeight = 128;

                using (var img = Image.FromFile(inputFileName))
                {
                    float widthRatio = img.Width / (float)desiredWidth;
                    float heightRatio = img.Height / (float)desiredHeight;

                    float ratio = heightRatio > widthRatio ? heightRatio : widthRatio;
                    int newWidth = Convert.ToInt32(Math.Floor(img.Width / ratio));
                    int newHeight = Convert.ToInt32(Math.Floor(img.Height / ratio));
                    using (var thumb = img.GetThumbnailImage(newWidth, newHeight, ThumbnailImageAbortCallback, IntPtr.Zero))
                    {
                        thumb.Save(outputFileName, ImageFormat.Jpeg);
                    }
                }

                var fs = new FileStream(outputFileName, FileMode.Open, FileAccess.Read);
                return fs;

            }
        }

        public static bool ThumbnailImageAbortCallback()
        {
            return true;
        }

        public static User User
        {
            get { 
                var firstName = Faker.Name.First();
                var lastName = Faker.Name.Last();
                
                var user = new User
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Name = firstName.Substring(0, 1) + lastName,
                        Password = Faker.Lorem.Words(1).First(),
                        EMail = firstName.Substring(0, 1) + lastName + "@" + Faker.Lorem.Words(1).First() + ".com",
                        Salt = Encryption.Salt(128)
                    };
                return user;
            }
        }
    }
}
