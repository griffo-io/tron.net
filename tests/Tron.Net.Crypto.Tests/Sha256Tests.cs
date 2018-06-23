using FluentAssertions;
using NUnit.Framework;
using Tron.Net.Common;

namespace Tron.Net.Crypto.Tests
{
    [TestFixture]
    public class Sha256Tests
    {
        [TestCase("A0E11973395042BA3C0B52B4CDF4E15EA77818F275", "CD5D4A7E8BE869C00E17F8F7712F41DBE2DDBD4D8EC36A7280CD578863717084")]
        public void Hash_WithControlledInput_ResultMatchesExpected(string x, string y)
        {
            var input = x.FromHexToByteArray();
            var hash = Sha256.Hash(input);
            var expected = y.FromHexToByteArray();
            hash.Should().Equal(expected);
        }

        [TestCase("A0E11973395042BA3C0B52B4CDF4E15EA77818F275", "10AE21E887E8FE30C591A22A5F8BB20EB32B2A739486DC5F3810E00BBDB58C5C")]
        public void HashTwice_WithControlledInput_ResultMatchesExpected(string x, string y)
        {
            var input = x.FromHexToByteArray();
            var hash = Sha256.HashTwice(input);
            var expected = y.FromHexToByteArray();
            hash.Should().Equal(expected);
        }
    }
}
