namespace Tron.Net.Client
{
    using System;
    using System.Linq;
    using Tron.Net.Common;
    using Tron.Net.Crypto;

    public sealed class WalletAddress
    {
        private readonly string _addressPrefix;
        private const string AddPreFixByteMainnet = "41";   //41 + address
        private const string AddPreFixByteTestnet = "a0";   //a0 + address
        
        private static string Encode58Check(byte[] input)
        {
            var hash0 = Sha256.Hash(input);
            var hash1 = Sha256.Hash(hash0);
            var inputCheck = new byte[input.Length + 4];
            Array.Copy(input, 0, inputCheck, 0, input.Length);
            Array.Copy(hash1, 0, inputCheck, input.Length, 4);
            return Base58.Encode(inputCheck);
        }

        private static byte[] Decode58Check(string input)
        {
            var decodeCheck = Base58.Decode(input);

            if (decodeCheck.Length <= 4)
            {
                return null;
            }

            var decodeData = new byte[decodeCheck.Length - 4];
            Array.Copy(decodeCheck, 0, decodeData, 0, decodeData.Length);

            var hash0 = Sha256.Hash(decodeData);
            var hash1 = Sha256.Hash(hash0);
            if (hash1[0] == decodeCheck[decodeData.Length] &&
                hash1[1] == decodeCheck[decodeData.Length + 1] &&
                hash1[2] == decodeCheck[decodeData.Length + 2] &&
                hash1[3] == decodeCheck[decodeData.Length + 3])
            {
                return decodeData;
            }

            return null;
        }

        internal WalletAddress(ECKey key, string prefix)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            Value = key.Pub.GetEncoded().Skip(1).ToArray();
            _addressPrefix = prefix;
        }

        public static WalletAddress MainNetWalletAddress(ECKey key = null)
        {
            return new WalletAddress(key ?? new ECKey(), AddPreFixByteMainnet);
        }

        public static WalletAddress TestNetWalletAddress(ECKey key = null)
        {
            return new WalletAddress(key ?? new ECKey(), AddPreFixByteTestnet);
        }

        public override string ToString()
        {
            var sha3Hash = Kecccack.ComputeHash(Value);
            var sha3HashBytes = new byte[20];
            Array.Copy(sha3Hash, sha3Hash.Length - 20, sha3HashBytes, 0, 20);
            var address = _addressPrefix + sha3HashBytes.ToHexString();
            var hexToByteArray = address.FromHexToByteArray();
            var hash = Sha256.HashTwice(hexToByteArray);
            var bytes = new byte[4];
            Array.Copy(hash, bytes, 4);
            var checksum = bytes.ToHexString();
            var addChecksum = (address + checksum).FromHexToByteArray();
            Array.Copy(hexToByteArray, addChecksum, hexToByteArray.Length);
            return Base58.Encode(addChecksum);
        }

        public byte[] Value { get; }

        public bool IsTestNet => _addressPrefix == AddPreFixByteTestnet;

        public bool IsMainNet => _addressPrefix == AddPreFixByteMainnet;
    }
}
