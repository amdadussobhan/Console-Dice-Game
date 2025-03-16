using ConsoleTables;

namespace Console_Dice_Game
{
    public class HelpTableGenerator
    {
        public static void DisplayHelpTable()
        {
            Console.WriteLine("\n\nProbability Table");
            List<Dice> diceList = GameManager.diceList;

            List<string> headers = ["Dice"];
            for (int i = 0; i < diceList.Count; i++)
                headers.Add($"{string.Join(",", diceList[i].Faces)}");

            ConsoleTable table = new([.. headers]);

            for (int i = 0; i < diceList.Count; i++)
            {
                List<string> row = [string.Join(",", diceList[i].Faces)];

                for (int j = 0; j < diceList.Count; j++)
                {
                    double probability = ProbabilityCalculator.CalculateProbability(diceList[i], diceList[j]);
                    row.Add($"{probability:P2}");
                }

                table.AddRow([.. row]);
            }

            table.Write();
        }
    }
}
