using Org.BouncyCastle.Crypto.Digests;
using System.Linq;
using System.Text;
using Tron.Net.Common;

namespace Tron.Net.Crypto
{
    /// <summary>
    /// Class from Nethereum. https://github.com/Nethereum/Nethereum/blob/master/src/Nethereum.Util/Sha3Keccack.cs
    /// </summary>
    public class Sha3Keccack
    {
        public static Sha3Keccack Current { get; } = new Sha3Keccack();

        public string CalculateHash(string value)
        {
            var input = Encoding.UTF8.GetBytes(value);
            var output = CalculateHash(input);
            return output.ToHexString();
        }

        public string CalculateHashFromHex(params string[] hexValues)
        {
            var joinedHex = string.Join("", hexValues.Select(x => RemoveHexPrefix(x))).ToArray();
            return CalculateHash(new string(joinedHex).FromHexToByteArray()).ToHexString();
        }

        public byte[] CalculateHash(byte[] value)
        {
            var digest = new KeccakDigest(256);
            var output = new byte[digest.GetDigestSize()];
            digest.BlockUpdate(value, 0, value.Length);
            digest.DoFinal(output, 0);
            return output;
        }

        public static string RemoveHexPrefix(string value)
        {
            return value.Substring(value.StartsWith("0x") ? 2 : 0);
        }
    }
}
