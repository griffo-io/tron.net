using System;

namespace Tron.Net.Crypto.SHA3
{
    //This implementation is taken from Copyright 2018 Joe Dluzen - https://bitbucket.org/jdluzen/sha3/src as at the moment of writing Tron.Net.Client it didn't have the implementation for .NET standard.
    //Attached license file to the package.

    public class Sha3 : System.Security.Cryptography.HashAlgorithm
    {
        public static Sha3 Sha3256()
        {
            return new Sha3(256);
        }

        public static Sha3 Sha3224()
        {
            return new Sha3(224);
        }
        public static Sha3 Sha3384()
        {
            return new Sha3(384);
        }

        public static Sha3 Sha3512()
        {
            return new Sha3(512);
        }

        #region Implementation

        private const int KeccakNumberOfRounds = 24;
        private const int KeccakLaneSizeInBits = 8 * 8;

        private readonly ulong[] RoundConstants;

        private ulong[] _state;
        private byte[] _buffer;
        private int _buffLength;

        private readonly int _keccakR;

        public int SizeInBytes => _keccakR / 8;

        public int HashByteLength => HashSizeValue / 8;

        public override bool CanReuseTransform => true;

        private Sha3(int hashBitLength)
        {
            if (hashBitLength != 224 && hashBitLength != 256 && hashBitLength != 384 && hashBitLength != 512)
                throw new ArgumentException("hashBitLength must be 224, 256, 384, or 512", "hashBitLength");
            
            _buffLength = 0;
            _state = new ulong[5 * 5];//1600 bits
            HashValue = null;

            HashSizeValue = hashBitLength;
            switch (hashBitLength)
            {
                case 224:
                    _keccakR = 1152;
                    break;
                case 256:
                    _keccakR = 1088;
                    break;
                case 384:
                    _keccakR = 832;
                    break;
                case 512:
                    _keccakR = 576;
                    break;
            }
            RoundConstants = new ulong[]
            {
                0x0000000000000001UL,
                0x0000000000008082UL,
                0x800000000000808aUL,
                0x8000000080008000UL,
                0x000000000000808bUL,
                0x0000000080000001UL,
                0x8000000080008081UL,
                0x8000000000008009UL,
                0x000000000000008aUL,
                0x0000000000000088UL,
                0x0000000080008009UL,
                0x000000008000000aUL,
                0x000000008000808bUL,
                0x800000000000008bUL,
                0x8000000000008089UL,
                0x8000000000008003UL,
                0x8000000000008002UL,
                0x8000000000000080UL,
                0x000000000000800aUL,
                0x800000008000000aUL,
                0x8000000080008081UL,
                0x8000000000008080UL,
                0x0000000080000001UL,
                0x8000000080008008UL
            };
        }

        private ulong Rol(ulong a, int offset)
        {
            return (((a) << ((offset) % KeccakLaneSizeInBits)) ^ ((a) >> (KeccakLaneSizeInBits - ((offset) % KeccakLaneSizeInBits))));
        }

        private void AddToBuffer(byte[] array, ref int offset, ref int count)
        {
            var amount = Math.Min(count, _buffer.Length - _buffLength);
            Buffer.BlockCopy(array, offset, _buffer, _buffLength, amount);
            offset += amount;
            _buffLength += amount;
            count -= amount;
        }

        public override byte[] Hash => HashValue;

        public override int HashSize => HashSizeValue;

        #endregion

        public override void Initialize()
        {
            _buffLength = 0;
            _state = new ulong[5 * 5];//1600 bits
            HashValue = null;
        }

        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (ibStart < 0)
                throw new ArgumentOutOfRangeException(nameof(ibStart));
            if (cbSize > array.Length)
                throw new ArgumentOutOfRangeException(nameof(cbSize));
            if (ibStart + cbSize > array.Length)
                throw new ArgumentOutOfRangeException("ibStart or cbSize");

            
            if (cbSize == 0)
                return;
            var sizeInBytes = SizeInBytes;
            if (_buffer == null)
                _buffer = new byte[sizeInBytes];
            var stride = sizeInBytes >> 3;
            var utemps = new ulong[stride];
            if (_buffLength == sizeInBytes)
                throw new Exception("Unexpected error, the internal buffer is full");
            AddToBuffer(array, ref ibStart, ref cbSize);
            if (_buffLength == sizeInBytes)//buffer full
            {
                Buffer.BlockCopy(_buffer, 0, utemps, 0, sizeInBytes);
                KeccakF(utemps, stride);
                _buffLength = 0;
            }
            for (; cbSize >= sizeInBytes; cbSize -= sizeInBytes, ibStart += sizeInBytes)
            {
                Buffer.BlockCopy(array, ibStart, utemps, 0, sizeInBytes);
                KeccakF(utemps, stride);
            }

            if (cbSize <= 0) return;
            Buffer.BlockCopy(array, ibStart, _buffer, _buffLength, cbSize);
            _buffLength += cbSize;
        }

        protected override byte[] HashFinal()
        {
            var sizeInBytes = SizeInBytes;
            var outb = new byte[HashByteLength];
            //    padding
            if (_buffer == null)
                _buffer = new byte[sizeInBytes];
            else
                Array.Clear(_buffer, _buffLength, sizeInBytes - _buffLength);
            _buffer[_buffLength++] = 1;
            _buffer[sizeInBytes - 1] |= 0x80;
            var stride = sizeInBytes >> 3;
            var utemps = new ulong[stride];
            Buffer.BlockCopy(_buffer, 0, utemps, 0, sizeInBytes);
            KeccakF(utemps, stride);
            Buffer.BlockCopy(_state, 0, outb, 0, HashByteLength);
            return outb;
        }

        private void KeccakF(ulong[] inb, int laneCount)
        {
            while (--laneCount >= 0)
            {
                _state[laneCount] ^= inb[laneCount];
            }

            ulong Aba, Abe, Abi, Abo, Abu;
            ulong Aga, Age, Agi, Ago, Agu;
            ulong Aka, Ake, Aki, Ako, Aku;
            ulong Ama, Ame, Ami, Amo, Amu;
            ulong Asa, Ase, Asi, Aso, Asu;
            ulong BCa, BCe, BCi, BCo, BCu;
            ulong Da, De, Di, Do, Du;
            ulong Eba, Ebe, Ebi, Ebo, Ebu;
            ulong Ega, Ege, Egi, Ego, Egu;
            ulong Eka, Eke, Eki, Eko, Eku;
            ulong Ema, Eme, Emi, Emo, Emu;
            ulong Esa, Ese, Esi, Eso, Esu;
            var round = laneCount;

            //copyFromState(A, state)
            Aba = _state[0];
            Abe = _state[1];
            Abi = _state[2];
            Abo = _state[3];
            Abu = _state[4];
            Aga = _state[5];
            Age = _state[6];
            Agi = _state[7];
            Ago = _state[8];
            Agu = _state[9];
            Aka = _state[10];
            Ake = _state[11];
            Aki = _state[12];
            Ako = _state[13];
            Aku = _state[14];
            Ama = _state[15];
            Ame = _state[16];
            Ami = _state[17];
            Amo = _state[18];
            Amu = _state[19];
            Asa = _state[20];
            Ase = _state[21];
            Asi = _state[22];
            Aso = _state[23];
            Asu = _state[24];

            for (round = 0; round < KeccakNumberOfRounds; round += 2)
            {
                //    prepareTheta
                BCa = Aba ^ Aga ^ Aka ^ Ama ^ Asa;
                BCe = Abe ^ Age ^ Ake ^ Ame ^ Ase;
                BCi = Abi ^ Agi ^ Aki ^ Ami ^ Asi;
                BCo = Abo ^ Ago ^ Ako ^ Amo ^ Aso;
                BCu = Abu ^ Agu ^ Aku ^ Amu ^ Asu;

                //thetaRhoPiChiIotaPrepareTheta(round  , A, E)
                Da = BCu ^ Rol(BCe, 1);
                De = BCa ^ Rol(BCi, 1);
                Di = BCe ^ Rol(BCo, 1);
                Do = BCi ^ Rol(BCu, 1);
                Du = BCo ^ Rol(BCa, 1);

                Aba ^= Da;
                BCa = Aba;
                Age ^= De;
                BCe = Rol(Age, 44);
                Aki ^= Di;
                BCi = Rol(Aki, 43);
                Amo ^= Do;
                BCo = Rol(Amo, 21);
                Asu ^= Du;
                BCu = Rol(Asu, 14);
                Eba = BCa ^ ((~BCe) & BCi);
                Eba ^= RoundConstants[round];
                Ebe = BCe ^ ((~BCi) & BCo);
                Ebi = BCi ^ ((~BCo) & BCu);
                Ebo = BCo ^ ((~BCu) & BCa);
                Ebu = BCu ^ ((~BCa) & BCe);

                Abo ^= Do;
                BCa = Rol(Abo, 28);
                Agu ^= Du;
                BCe = Rol(Agu, 20);
                Aka ^= Da;
                BCi = Rol(Aka, 3);
                Ame ^= De;
                BCo = Rol(Ame, 45);
                Asi ^= Di;
                BCu = Rol(Asi, 61);
                Ega = BCa ^ ((~BCe) & BCi);
                Ege = BCe ^ ((~BCi) & BCo);
                Egi = BCi ^ ((~BCo) & BCu);
                Ego = BCo ^ ((~BCu) & BCa);
                Egu = BCu ^ ((~BCa) & BCe);

                Abe ^= De;
                BCa = Rol(Abe, 1);
                Agi ^= Di;
                BCe = Rol(Agi, 6);
                Ako ^= Do;
                BCi = Rol(Ako, 25);
                Amu ^= Du;
                BCo = Rol(Amu, 8);
                Asa ^= Da;
                BCu = Rol(Asa, 18);
                Eka = BCa ^ ((~BCe) & BCi);
                Eke = BCe ^ ((~BCi) & BCo);
                Eki = BCi ^ ((~BCo) & BCu);
                Eko = BCo ^ ((~BCu) & BCa);
                Eku = BCu ^ ((~BCa) & BCe);

                Abu ^= Du;
                BCa = Rol(Abu, 27);
                Aga ^= Da;
                BCe = Rol(Aga, 36);
                Ake ^= De;
                BCi = Rol(Ake, 10);
                Ami ^= Di;
                BCo = Rol(Ami, 15);
                Aso ^= Do;
                BCu = Rol(Aso, 56);
                Ema = BCa ^ ((~BCe) & BCi);
                Eme = BCe ^ ((~BCi) & BCo);
                Emi = BCi ^ ((~BCo) & BCu);
                Emo = BCo ^ ((~BCu) & BCa);
                Emu = BCu ^ ((~BCa) & BCe);

                Abi ^= Di;
                BCa = Rol(Abi, 62);
                Ago ^= Do;
                BCe = Rol(Ago, 55);
                Aku ^= Du;
                BCi = Rol(Aku, 39);
                Ama ^= Da;
                BCo = Rol(Ama, 41);
                Ase ^= De;
                BCu = Rol(Ase, 2);
                Esa = BCa ^ ((~BCe) & BCi);
                Ese = BCe ^ ((~BCi) & BCo);
                Esi = BCi ^ ((~BCo) & BCu);
                Eso = BCo ^ ((~BCu) & BCa);
                Esu = BCu ^ ((~BCa) & BCe);

                //    prepareTheta
                BCa = Eba ^ Ega ^ Eka ^ Ema ^ Esa;
                BCe = Ebe ^ Ege ^ Eke ^ Eme ^ Ese;
                BCi = Ebi ^ Egi ^ Eki ^ Emi ^ Esi;
                BCo = Ebo ^ Ego ^ Eko ^ Emo ^ Eso;
                BCu = Ebu ^ Egu ^ Eku ^ Emu ^ Esu;

                //thetaRhoPiChiIotaPrepareTheta(round+1, E, A)
                Da = BCu ^ Rol(BCe, 1);
                De = BCa ^ Rol(BCi, 1);
                Di = BCe ^ Rol(BCo, 1);
                Do = BCi ^ Rol(BCu, 1);
                Du = BCo ^ Rol(BCa, 1);

                Eba ^= Da;
                BCa = Eba;
                Ege ^= De;
                BCe = Rol(Ege, 44);
                Eki ^= Di;
                BCi = Rol(Eki, 43);
                Emo ^= Do;
                BCo = Rol(Emo, 21);
                Esu ^= Du;
                BCu = Rol(Esu, 14);
                Aba = BCa ^ ((~BCe) & BCi);
                Aba ^= RoundConstants[round + 1];
                Abe = BCe ^ ((~BCi) & BCo);
                Abi = BCi ^ ((~BCo) & BCu);
                Abo = BCo ^ ((~BCu) & BCa);
                Abu = BCu ^ ((~BCa) & BCe);

                Ebo ^= Do;
                BCa = Rol(Ebo, 28);
                Egu ^= Du;
                BCe = Rol(Egu, 20);
                Eka ^= Da;
                BCi = Rol(Eka, 3);
                Eme ^= De;
                BCo = Rol(Eme, 45);
                Esi ^= Di;
                BCu = Rol(Esi, 61);
                Aga = BCa ^ ((~BCe) & BCi);
                Age = BCe ^ ((~BCi) & BCo);
                Agi = BCi ^ ((~BCo) & BCu);
                Ago = BCo ^ ((~BCu) & BCa);
                Agu = BCu ^ ((~BCa) & BCe);

                Ebe ^= De;
                BCa = Rol(Ebe, 1);
                Egi ^= Di;
                BCe = Rol(Egi, 6);
                Eko ^= Do;
                BCi = Rol(Eko, 25);
                Emu ^= Du;
                BCo = Rol(Emu, 8);
                Esa ^= Da;
                BCu = Rol(Esa, 18);
                Aka = BCa ^ ((~BCe) & BCi);
                Ake = BCe ^ ((~BCi) & BCo);
                Aki = BCi ^ ((~BCo) & BCu);
                Ako = BCo ^ ((~BCu) & BCa);
                Aku = BCu ^ ((~BCa) & BCe);

                Ebu ^= Du;
                BCa = Rol(Ebu, 27);
                Ega ^= Da;
                BCe = Rol(Ega, 36);
                Eke ^= De;
                BCi = Rol(Eke, 10);
                Emi ^= Di;
                BCo = Rol(Emi, 15);
                Eso ^= Do;
                BCu = Rol(Eso, 56);
                Ama = BCa ^ ((~BCe) & BCi);
                Ame = BCe ^ ((~BCi) & BCo);
                Ami = BCi ^ ((~BCo) & BCu);
                Amo = BCo ^ ((~BCu) & BCa);
                Amu = BCu ^ ((~BCa) & BCe);

                Ebi ^= Di;
                BCa = Rol(Ebi, 62);
                Ego ^= Do;
                BCe = Rol(Ego, 55);
                Eku ^= Du;
                BCi = Rol(Eku, 39);
                Ema ^= Da;
                BCo = Rol(Ema, 41);
                Ese ^= De;
                BCu = Rol(Ese, 2);
                Asa = BCa ^ ((~BCe) & BCi);
                Ase = BCe ^ ((~BCi) & BCo);
                Asi = BCi ^ ((~BCo) & BCu);
                Aso = BCo ^ ((~BCu) & BCa);
                Asu = BCu ^ ((~BCa) & BCe);
            }

            //copyToState(state, A)
            _state[0] = Aba;
            _state[1] = Abe;
            _state[2] = Abi;
            _state[3] = Abo;
            _state[4] = Abu;
            _state[5] = Aga;
            _state[6] = Age;
            _state[7] = Agi;
            _state[8] = Ago;
            _state[9] = Agu;
            _state[10] = Aka;
            _state[11] = Ake;
            _state[12] = Aki;
            _state[13] = Ako;
            _state[14] = Aku;
            _state[15] = Ama;
            _state[16] = Ame;
            _state[17] = Ami;
            _state[18] = Amo;
            _state[19] = Amu;
            _state[20] = Asa;
            _state[21] = Ase;
            _state[22] = Asi;
            _state[23] = Aso;
            _state[24] = Asu;

        }

    }
}
