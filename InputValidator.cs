
namespace Console_Dice_Game
{
    public class InputValidator
    {
        public int CheckValue(Dictionary<string, string> validList, string message)
        {
            string inputValue;
            while (true)
            {
                Console.WriteLine($"\n{message}");

                foreach (var item in validList)
                    Console.WriteLine($"{item.Key} - {item.Value}");

                inputValue = Console.ReadKey().KeyChar.ToString();

                if (inputValue.Equals("x", StringComparison.OrdinalIgnoreCase))
                    Environment.Exit(0);

                if (inputValue.Equals("?"))
                {
                    HelpTableGenerator.DisplayHelpTable();
                    continue;
                }

                if (validList.ContainsKey(inputValue))
                    break;
                
                Console.WriteLine($"\nInvalid input. Please enter only : {string.Join(",", validList.Keys)}.");
            }

            return int.Parse(inputValue);
        }
    }
}
