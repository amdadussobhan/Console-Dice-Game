using Org.BouncyCastle.Crypto.Prng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Console_Dice_Game
{
    class FirstMove
    {
        private FairRandomGenerator randomGenerator;

        public FirstMove()
        {
            this.randomGenerator = new FairRandomGenerator();
        }

        public int computerGuess()
        {
            int guessNumber = RandomNumberGenerator.GetInt32(0, 2);
            var hmac = randomGenerator.GenerateHMAC(guessNumber);
            Console.WriteLine($"I selected a random value in the range 0..1");
            Console.WriteLine($"(HMAC={hmac}).");
            Console.WriteLine();

            return guessNumber; }

        public int userGuess()
        {
            string guessNumber;

            while (true)
            {
                Console.WriteLine($"Try to guess my selection.");
                Console.WriteLine($"0 - 0");
                Console.WriteLine($"1 - 1");
                Console.WriteLine($"X - exit");
                Console.WriteLine($"? - help");

                guessNumber = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();

                // Check if the input is valid (either 0, 1, x, or X)
                if (guessNumber == "0" || guessNumber == "1")
                    break;

                if (guessNumber.Equals("x", StringComparison.OrdinalIgnoreCase))
                    Environment.Exit(0);

                if (guessNumber.Equals("?"))
                {
                    Console.WriteLine("Display Probability Table");
                    continue;
                }

                Console.WriteLine("Invalid input. Please enter either 0, 1 or X, ?");
                Console.WriteLine();
            }

            return int.Parse(guessNumber);
        }

        public void checkMove()
        {
            int computerGuess = this.computerGuess();
            int userGuess = this.userGuess();
            Console.WriteLine($"Your selection: {computerGuess}");
            Console.WriteLine($"My selection: {userGuess}");
            Console.WriteLine($"(KEY={BitConverter.ToString(randomGenerator._secretKey).Replace("-", "")}).");
            
            string subject = "I";
            if (computerGuess == userGuess)
                subject = "You";

            Console.WriteLine();
            Console.WriteLine($"{subject} make the first move.");
        }
    }
}
