using System;
using Tron.Net.Common;
using Tron.Net.Crypto;

namespace Tron.Net.Client
{
    public sealed class WalletAddress
    {
        private readonly byte _addressPrefix;
        private const byte AddPreFixByteMainnet = (byte)0x41;   //41 + address
        private const byte AddPreFixByteTestnet = (byte)0xa0;   //a0 + address
        private const byte AddressSize = 21;

        private static string Encode58Check(byte[] input) {
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

        internal WalletAddress(string address, byte prefix)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentNullException(nameof(address));
            }

            Value = Decode58Check(address);
            _addressPrefix = prefix;
        }

        public static WalletAddress MainNetWalletAddress(string address)
        {
            return new WalletAddress(address, AddPreFixByteMainnet);
        }

        public static WalletAddress TestNetWalletAddress(string address)
        {
            return new WalletAddress(address, AddPreFixByteTestnet);
        }

        public bool Valid()
        {
            if (Value == null)
            {
                return false;
            }
            if (Value.Length != AddressSize)
            {
                return false;
            }
            var preFixbyte = Value[0];

            if (preFixbyte != _addressPrefix)
            {
                return false;
            }

            //Future rules;
            return true;
        }
        
        public override string ToString()
        {
            return Encode58Check(Value);
        }

        public byte[] Value { get; }
    }
}
