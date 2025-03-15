using Org.BouncyCastle.Crypto.Prng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Console_Dice_Game
{
    class ManageFirstMove
    {
        private InputValidation inputValidation;
        private FairRandomGenerator randomGenerator;

        public ManageFirstMove()
        {
            this.inputValidation = new InputValidation();
            this.randomGenerator = new FairRandomGenerator();
        }

        public int userGuess()
        {
            var validList = new Dictionary<string, string>
            {
                { "0", "0" },
                { "1", "1" },
                { "X", "exit" },
                { "?", "help" }
            };

            return inputValidation.checkValue(validList, $"Try to guess my selection:");
        }

        public string checkMove()
        {
            int computerChoice = randomGenerator.ComputerNumber(2);
            int userChoice = this.userGuess();
            Console.WriteLine($"\nYour selection: {userChoice}");
            Console.WriteLine($"My selection: {computerChoice}");
            Console.WriteLine($"(KEY={BitConverter.ToString(randomGenerator._secretKey).Replace("-", "")}).");
            
            string subject = "I";
            if (computerChoice == userChoice)
                subject = "You";

            Console.WriteLine($"\n{subject} make the first move.");
            return subject;
        }
    }
}
