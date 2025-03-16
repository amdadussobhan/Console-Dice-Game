
namespace Console_Dice_Game
{
    class FirstMoveChecker
    {
        private readonly InputValidator inputValidator = new();
        private readonly FairRandomGenerator fairGenerator = new();

        public int UserGuess()
        {
            var validList = new Dictionary<string, string>
            {
                { "0", "0" },
                { "1", "1" },
                { "X", "exit" },
                { "?", "help" }
            };

            return inputValidator.CheckValue(validList, $"Try to guess my selection:");
        }

        public string CheckMove()
        {
            int computerChoice = fairGenerator.ComputerNumber(2);
            int userChoice = this.UserGuess();
            Console.WriteLine($"\n\nYour selection: {userChoice} \nMy selection: {computerChoice}");
            Console.WriteLine($"(KEY={BitConverter.ToString(fairGenerator._secretKey).Replace("-", "")}).");
            
            string subject = (computerChoice == userChoice ? "You" : "I");
            Console.WriteLine($"\n{subject} make the first move.");
            return subject;
        }
    }
}
