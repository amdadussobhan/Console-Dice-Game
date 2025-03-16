using System.Security.Cryptography;
using System.Text;
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

        public int ComputerNumber(int maxValue)
        {
            int randomNumber = RandomNumberGenerator.GetInt32(0, maxValue);
            var hmac = GenerateHMAC(randomNumber);
            Console.WriteLine($"I selected a random value in the range 0..{maxValue - 1}");
            Console.WriteLine($"(HMAC={hmac}).");

            return randomNumber;
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
