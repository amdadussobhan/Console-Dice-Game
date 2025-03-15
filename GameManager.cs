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
        private FairRandomGenerator randomGenerator;
        private FirstMove firstMove;

        public GameManager(List<Dice> diceList)
        {
            this.diceList = diceList;
            this.randomGenerator = new FairRandomGenerator();
            this.firstMove = new FirstMove();
        }

        public void StartGame()
        {
            Console.WriteLine($"Let's determine who makes the first move.");
            firstMove.checkMove();            
        }
    }
}
