using System.Text;
using FluentAssertions;
using NUnit.Framework;
using Tron.Net.Common;
using Tron.Net.Crypto.SHA3;

namespace Tron.Net.Crypto.Tests
{
    [TestFixture]
    public class Sha3Tests
    {
        [TestCase("The quick brown fox jumps over the lazy dog", "4d741b6f1eb29cb2a9b9911c82f56fa8d73b04959d3d9d222895df6c0b28aa15")]
        [TestCase("abc", "4e03657aea45a94fc7d47ba826c8d667c0d1e6e33a64a036ec44f58fa12d6c45")]
        [TestCase("abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq", "45d3b367a6904e6e8d502ee04999a7c27647f91fa845d456525fd352ae3d7371")]
        public void Sha3256ComputeHash_WithControlledInput_ResultMatchesExpected(string input, string expected)
        {
            var hash = Sha3.Sha3256().ComputeHash(Encoding.UTF8.GetBytes(input));
            hash.ToHexString().Should().Be(expected);
        }
        

        [TestCase("The quick brown fox jumps over the lazy dog", "283990fa9d5fb731d786c5bbee94ea4db4910f18c62c03d173fc0a5e494422e8a0b3da7574dae7fa0baf005e504063b3")]
        [TestCase("abc", "f7df1165f033337be098e7d288ad6a2f74409d7a60b49c36642218de161b1f99f8c681e4afaf31a34db29fb763e3c28e")]
        [TestCase("abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq", "b41e8896428f1bcbb51e17abd6acc98052a3502e0d5bf7fa1af949b4d3c855e7c4dc2c390326b3f3e74c7b1e2b9a3657")]
        public void Sha3384ComputeHash_WithControlledInput_ResultMatchesExpected(string input, string expected)
        {
            var hash = Sha3.Sha3384().ComputeHash(Encoding.UTF8.GetBytes(input));
            hash.ToHexString().Should().Be(expected);
        }


        [TestCase("The quick brown fox jumps over the lazy dog", "d135bb84d0439dbac432247ee573a23ea7d3c9deb2a968eb31d47c4fb45f1ef4422d6c531b5b9bd6f449ebcc449ea94d0a8f05f62130fda612da53c79659f609")]
        [TestCase("abc", "18587dc2ea106b9a1563e32b3312421ca164c7f1f07bc922a9c83d77cea3a1e5d0c69910739025372dc14ac9642629379540c17e2a65b19d77aa511a9d00bb96")]
        [TestCase("abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq", "6aa6d3669597df6d5a007b00d09c20795b5c4218234e1698a944757a488ecdc09965435d97ca32c3cfed7201ff30e070cd947f1fc12b9d9214c467d342bcba5d")]
        public void Sha3512ComputeHash_WithControlledInput_ResultMatchesExpected(string input, string expected)
        {
            var hash = Sha3.Sha3512().ComputeHash(Encoding.UTF8.GetBytes(input));
            hash.ToHexString().Should().Be(expected);
        }
    }
}
