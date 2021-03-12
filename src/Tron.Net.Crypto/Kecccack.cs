using Org.BouncyCastle.Crypto.Digests;

namespace Tron.Net.Crypto
{
    public static class Kecccack
    {
        public static byte[] ComputeHash(byte[] value)
        {
            var digest = new KeccakDigest(256);
            var output = new byte[digest.GetDigestSize()];
            digest.BlockUpdate(value, 0, value.Length);
            digest.DoFinal(output, 0);
            return output;
        }
    }
}
