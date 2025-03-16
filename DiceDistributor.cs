using System.Security.Cryptography;

namespace Console_Dice_Game
{
    public class DiceDistributor
    {
        private readonly InputValidator inputValidator = new();

        public static int ComputerChoice(List<Dice> diceList)
        {
            int computerIndex = RandomNumberGenerator.GetInt32(0, diceList.Count);
            Console.WriteLine($"I choose the {string.Join(",", diceList[computerIndex].Faces)} dice.");

            return computerIndex;
        }

        public int UserChoice(List<Dice> diceList)
        {
            var validList = new Dictionary<string, string>();

            for (int i = 0; i < diceList.Count; i++)            
                validList.Add(i+"", string.Join(",", diceList[i].Faces));
            
            validList.Add("X", "exit"); validList.Add("?", "help");

            int inputValue = inputValidator.CheckValue(validList, "Choose your dice:");
            Console.WriteLine($"\n\nYour selection: {inputValue} \nYou choose the {string.Join(",", diceList[inputValue].Faces)} dice.");
            return inputValue;
        }

        public List<Dice> ChooseDice(string firstMover, List<Dice> diceList)
        {
            List<Dice> dices = [.. diceList];
            bool isComputerFirst = firstMover.Equals("I");

            int firstChoiceIndex = isComputerFirst ? ComputerChoice(dices) : UserChoice(dices);
            Dice? computerDice = isComputerFirst ? dices[firstChoiceIndex] : null;
            Dice? userDice = isComputerFirst ? null : dices[firstChoiceIndex];

            dices.RemoveAt(firstChoiceIndex);

            int secondChoiceIndex = isComputerFirst ? UserChoice(dices) : ComputerChoice(dices);
            userDice = isComputerFirst ? dices[secondChoiceIndex] : userDice;
            computerDice = isComputerFirst ? computerDice : dices[secondChoiceIndex];

            Console.WriteLine("\nIt's time for my roll.");

            return [computerDice, userDice];
        }
    }
}
