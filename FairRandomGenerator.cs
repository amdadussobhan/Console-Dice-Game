using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;

namespace Console_Dice_Game
{
    public class FairRandomGenerator
    {
        public byte[] _secretKey;

        public FairRandomGenerator()
        {
            _secretKey = GenerateRandomKey();
        }

        public string GenerateHMAC(int number)
        {
            var hmac = new HMac(new Sha3Digest(256));
            hmac.Init(new Org.BouncyCastle.Crypto.Parameters.KeyParameter(GenerateRandomKey()));

            byte[] messageBytes = Encoding.UTF8.GetBytes(number.ToString());
            hmac.BlockUpdate(messageBytes, 0, messageBytes.Length);

            byte[] result = new byte[hmac.GetMacSize()];
            hmac.DoFinal(result, 0);

            return BitConverter.ToString(result).Replace("-", "");
        }

        public byte[] GenerateRandomKey()
        {
            byte[] key = new byte[32];
            RandomNumberGenerator.Fill(key);
            _secretKey = key;
            return key;
        }
    }
}
