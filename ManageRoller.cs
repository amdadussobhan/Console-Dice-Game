
namespace Console_Dice_Game
{
    public class ManageRoller
    {
        private readonly InputValidator inputValidator = new();
        private readonly FairRandomGenerator fairGenerator = new();

        public int UserRoll()
        {
            var validList = new Dictionary<string, string>();

            for (int i = 0; i < 6; i++)
                validList.Add(i + "", i + "");

            validList.Add("X", "exit");
            validList.Add("?", "help");

            return inputValidator.CheckValue(validList, "Add your number modulo 6:");
        }

        public int CheckRoll(Dice dice)
        {
            int computerRoll = fairGenerator.ComputerNumber(6);
            int userRollValue = UserRoll();
            Console.WriteLine($"\n\nYour selection: {userRollValue} \nMy selection: {computerRoll}");
            Console.WriteLine($"(KEY={BitConverter.ToString(fairGenerator._secretKey).Replace("-", "")}).");
            int modValue = (computerRoll + userRollValue) % 6;
            Console.WriteLine($"\nThe fair number generation result is {computerRoll} + {userRollValue} = {modValue} (mod 6).");
            return dice.Faces[modValue];
        }
    }
}
