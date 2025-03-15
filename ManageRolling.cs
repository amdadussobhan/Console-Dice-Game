using Org.BouncyCastle.Crypto.Prng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Console_Dice_Game
{
    public class ManageRolling
    {
        private InputValidation inputValidation;
        private FairRandomGenerator fairRandomGenerator;

        public ManageRolling()
        {
            this.inputValidation = new InputValidation();
            this.fairRandomGenerator = new FairRandomGenerator();
        }

        public int userRoll(Dice dice)
        {
            var validList = new Dictionary<string, string>();

            for (int i = 0; i < 6; i++)
                validList.Add(i + "", i + "");

            validList.Add("X", "exit");
            validList.Add("?", "help");

            return inputValidation.checkValue(validList, "Add your number modulo 6:");
        }

        public int checkRoll(Dice dice)
        {
            int computerRoll = fairRandomGenerator.ComputerNumber(6);
            int userRollValue = userRoll(dice);
            Console.WriteLine($"\nYour selection: {userRollValue}");
            Console.WriteLine($"My selection: {computerRoll}");
            Console.WriteLine($"(KEY={BitConverter.ToString(fairRandomGenerator._secretKey).Replace("-", "")}).");
            int modValue = (computerRoll + userRollValue) % 6;
            Console.WriteLine($"\nThe fair number generation result is {computerRoll} + {userRollValue} = {modValue} (mod 6).");
            return dice.Faces[modValue];
        }
    }
}
