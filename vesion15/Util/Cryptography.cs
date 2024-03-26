using System.Security.Cryptography;
using System.Text;

namespace vesion15.Util
{
    public class Cryptography
    {
        public static string Gethash(HashAlgorithm hashAlgorithm, string input)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            var hasOfInput = Gethash(hashAlgorithm, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hasOfInput, hash) == 0;
        }
    }
}
