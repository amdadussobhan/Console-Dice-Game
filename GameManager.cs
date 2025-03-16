
namespace Console_Dice_Game
{
    public class GameManager
    {
        public static List<Dice> diceList = [];
        private readonly DiceDistributor diceDistributor = new();
        private readonly FirstMoveChecker firstMoveChecker = new();
        private readonly ManageRoller manageRoller = new();

        public void StartGame()
        {
            Console.WriteLine("\nLet's determine who makes the first move.");
            string firstMover = firstMoveChecker.CheckMove();
            var dices = diceDistributor.ChooseDice(firstMover, diceList);

            int computerResult = manageRoller.CheckRoll(dices[0]);
            Console.WriteLine($"My roll result is {computerResult}.\n\nIt's time for your roll.");

            int userResult = manageRoller.CheckRoll(dices[1]);
            Console.WriteLine($"Your roll result is {userResult}.");

            if (computerResult == userResult)
                Console.WriteLine($"It's a tie. ({computerResult} == {userResult})");
            else
                Console.WriteLine(computerResult > userResult ? $"I Win ({computerResult} > {userResult})" : $"You win ({computerResult} < {userResult})");
        }
    }
}
