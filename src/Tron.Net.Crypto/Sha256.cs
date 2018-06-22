using System.IO;
using System.Security.Cryptography;

namespace Tron.Net.Crypto
{
    public static class Sha256
    {
        public static byte[] Hash(byte[] input, SHA256Managed hash = null)
        {
            byte[] hashBytes;
            hash = hash ?? new SHA256Managed();

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
            var hash = new SHA256Managed();
            return Hash(Hash(input, hash), hash);
        }
    }
}
