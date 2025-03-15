using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Dice_Game
{
    class InputValidation
    {
        public int checkValue(Dictionary<string, string> validList, string message)
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
                    Console.WriteLine("\nDisplay Probability Table");
                    continue;
                }

                if (validList.ContainsKey(inputValue))
                    break;
                else
                    Console.WriteLine($"\nInvalid input. Please enter only those value: {string.Join(",", validList.Keys)}.");
            }

            return int.Parse(inputValue);
        }
    }
}
