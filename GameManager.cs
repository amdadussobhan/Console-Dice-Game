using Org.BouncyCastle.Crypto.Prng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Console_Dice_Game
{
    class GameManager
    {
        private List<Dice> diceList;
        private DiceDistribute selectDice;
        private ManageFirstMove firstMove;
        private ManageRolling manageRolling;
        private FairRandomGenerator fairRandomGenerator;

        public GameManager(List<Dice> diceList)
        {
            this.diceList = diceList;
            this.selectDice = new DiceDistribute();
            this.firstMove = new ManageFirstMove();
            this.manageRolling = new ManageRolling();
            this.fairRandomGenerator = new FairRandomGenerator();
        }

        public void StartGame()
        {
            Console.WriteLine("Let's determine who makes the first move.");
            string firstMover = firstMove.checkMove();
            var dices = selectDice.chooseDice(firstMover, diceList);

            int computerResult = manageRolling.checkRoll(dices[0]);
            Console.WriteLine($"My roll result is {computerResult}.");

            Console.WriteLine("\nIt's time for your roll.");
            int userResult = manageRolling.checkRoll(dices[1]);
            Console.WriteLine($"Your roll result is {userResult}.");

            if (computerResult == userResult)
                Console.WriteLine($"It's a tie. {computerResult} = {userResult}");
            else
                Console.WriteLine(computerResult > userResult ? $"I Win {computerResult} > {userResult}" : $"You win {computerResult} < {userResult}");
        }
    }
}
