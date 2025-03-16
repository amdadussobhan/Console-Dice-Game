
namespace Console_Dice_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Dice> diceList = DiceParser.Parse(args);
                GameManager gameManager = new();
                GameManager.diceList = diceList;
                gameManager.StartGame();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}