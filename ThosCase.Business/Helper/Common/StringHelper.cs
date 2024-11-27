using System.Security.Cryptography;
using System.Text;

namespace ThosCase.Business.Helper.Common
{
    public static class StringHelper
    {
        public static string ToGetSalt(this string @string)
        {
            byte[] bytes = new byte[128 / 8];
            using (var keyGenerator = RandomNumberGenerator.Create())
            {
                keyGenerator.GetBytes(bytes);
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
        public static string ToEncoded(this string @string)
        {
            SHA512CryptoServiceProvider cryptoServiceProvider = new SHA512CryptoServiceProvider();
            @string = Convert.ToBase64String(cryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(@string)));
            return @string;
        }
    }
}
