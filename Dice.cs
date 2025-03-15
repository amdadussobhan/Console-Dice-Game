using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Console_Dice_Game
{
    public class Dice
    {
        public int[] Faces { get; private set; }

        public Dice(int[] faces)
        {
            Faces = faces;
        }
    }
}
