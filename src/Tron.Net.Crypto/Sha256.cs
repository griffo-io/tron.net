using System.IO;
using System.Security.Cryptography;

namespace Tron.Net.Crypto
{
    public static class Sha256
    {
        public static byte[] Hash(byte[] input)
        {
            byte[] hashBytes;
            var hash = new SHA256Managed();
            using (var stream = new MemoryStream(input))
            {
                
                try
                {
                    hashBytes = hash.ComputeHash(stream);
                }
                finally
                {
                    hash.Clear();
                }
            }

            return hashBytes;
        }

        public static byte[] HashTwice(byte[] input)
        {
            return Hash(Hash(input));
        }
    }
}
