using FluentAssertions;
using NUnit.Framework;

namespace Tron.Net.Common.Tests
{
    [TestFixture]
    public class Base58Tests
    {
        [TestCase("A090B2C2D45E7D674A8E072AF7B92CDCD9D914EF7247E8EBF7", "27cGbzXvwq1KzFcq3nKP9L3mGu8JEko5fVg")]
        public void Encode_WithControlledInput_ResultMatchesExpected(string input, string expected)
        {
            var base58 = Base58.Encode(input.FromHexToByteArray());            
            base58.Should().Be(expected);
        }

        [TestCase("27cGbzXvwq1KzFcq3nKP9L3mGu8JEko5fVg", "A090B2C2D45E7D674A8E072AF7B92CDCD9D914EF7247E8EBF7")]
        public void Decode_WithControlledInput_ResultMatchesExpected(string input, string expected)
        {
            var base58 = Base58.Decode(input);            
            base58.Should().Equal(expected.FromHexToByteArray());
        }
    }
}
