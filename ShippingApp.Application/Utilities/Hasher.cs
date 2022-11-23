using System.Security.Cryptography;
using System.Text;

namespace ShippingApp.Application.Utilities
{
    public static class Hasher
    {
        public static string HashPassword(string input)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
            var hashedPassword = Encoding.ASCII.GetString(md5Data);

            return hashedPassword;
        }
    }
}