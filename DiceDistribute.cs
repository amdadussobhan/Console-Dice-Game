using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Console_Dice_Game
{
    public class DiceDistribute
    {
        private InputValidation inputValidation;

        public DiceDistribute()
        {
            this.inputValidation = new InputValidation();
        }

        public int computerChoice(List<Dice> diceList)
        {
            int computerIndex = RandomNumberGenerator.GetInt32(0, diceList.Count);
            Console.WriteLine($"I choose the {string.Join(",", diceList[computerIndex].Faces)} dice.");

            return computerIndex;
        }

        public int userChoice(List<Dice> diceList)
        {
            var validList = new Dictionary<string, string>();

            for (int i = 0; i < diceList.Count; i++)            
                validList.Add(i+"", string.Join(",", diceList[i].Faces));
            
            validList.Add("X", "exit");
            validList.Add("?", "help");

            int inputValue = inputValidation.checkValue(validList, "Choose your dice:");
            Console.WriteLine($"\nYour selection: {inputValue}");
            Console.WriteLine($"You choose the {string.Join(",", diceList[inputValue].Faces)} dice.");
            return inputValue;
        }

        public List<Dice> chooseDice(string firstMover, List<Dice> diceList)
        {
            bool isComputerFirst = firstMover.Equals("I");

            int firstChoiceIndex = isComputerFirst ? computerChoice(diceList) : userChoice(diceList);
            Dice? computerDice = isComputerFirst ? diceList[firstChoiceIndex] : null;
            Dice? userDice = isComputerFirst ? null : diceList[firstChoiceIndex];

            diceList.RemoveAt(firstChoiceIndex);

            int secondChoiceIndex = isComputerFirst ? userChoice(diceList) : computerChoice(diceList);
            userDice = isComputerFirst ? diceList[secondChoiceIndex] : userDice;
            computerDice = isComputerFirst ? computerDice : diceList[secondChoiceIndex];

            Console.WriteLine("\nIt's time for my roll.");

            return [computerDice, userDice];
        }
    }
}
