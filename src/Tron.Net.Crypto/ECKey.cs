using System;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Security;

namespace Tron.Net.Crypto
{
    public class ECKey
    {
        private static readonly ECDomainParameters Curve;
        private static readonly BigInteger Secp256K1N;
        private static readonly BigInteger HalfCurveOrder;
        private static readonly SecureRandom SecureRandom;
        private static readonly X9ECParameters Params;

        private ECPoint _pub;
        static ECKey()
        {
            Params = SecNamedCurves.GetByName("secp256k1");
            Curve = new ECDomainParameters(Params.Curve, Params.G, Params.N, Params.H);
            Secp256K1N = new BigInteger("fffffffffffffffffffffffffffffffebaaedce6af48a03bbfd25e8cd0364141", 16);
            HalfCurveOrder = Params.N.ShiftRight(1);
            SecureRandom = new SecureRandom();
        }

        public ECKey()
        {
            var parameters = new ECDomainParameters(Params.Curve, Params.G, Params.N, Params.H);
            var generator = new ECKeyPairGenerator();
            generator.Init(new ECKeyGenerationParameters(parameters, SecureRandom));
            var pair = generator.GenerateKeyPair();
            var publicKeyParameters = (ECPublicKeyParameters)pair.Public;
            _pub = publicKeyParameters.Q;
            
        }
    }
}
