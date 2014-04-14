using System;
using System.Runtime.InteropServices;
using System.Security;

namespace DMSPlugins
{
    public static class Extensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static SecureString Secure(this String str)
        {
             var secure = new SecureString();

            foreach (var c in str.ToCharArray()) 
                secure.AppendChar(c);
            return secure;
        }

        public static String Insecure(this SecureString str)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(str);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            } 
        }
    }
}