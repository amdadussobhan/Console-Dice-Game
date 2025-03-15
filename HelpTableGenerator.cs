using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Dice_Game
{
    public class HelpTableGenerator
    {
        public static void DisplayHelpTable(List<Dice> diceList)
        {
            Console.WriteLine("Help Table:");
            Console.Write("Dice\t");
            for (int i = 0; i < diceList.Count; i++)
            {
                Console.Write($"D{i + 1}\t");
            }
            Console.WriteLine();

            for (int i = 0; i < diceList.Count; i++)
            {
                Console.Write($"D{i + 1}\t");
                for (int j = 0; j < diceList.Count; j++)
                {
                    if (i == j)
                    {
                        Console.Write("-\t");
                    }
                    else
                    {
                        double probability = ProbabilityCalculator.CalculateProbability(diceList[i], diceList[j]);
                        Console.Write($"{probability:P2}\t");
                    }
                }
                Console.WriteLine();
            }
        }        
    }
}
