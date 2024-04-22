using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        /*
         * The Game class should create three die objects, roll them, sum and report the total of the three dice rolls.
         *
         * EXTRA: For extra requirements (these aren't required though), the dice rolls could be managed so that the
         * rolls could be continous, and the totals and other statistics could be summarised for example.
         */
        public bool player1 = true;
        public bool gameend = false;
        public bool aienabled = false;

        public int[] Roll2()
        {
            Die Die1 = new Die();
            Die Die2 = new Die();
            int roll1st = Die1.Roll();
            Thread.Sleep(100);
            int roll2nd = Die2.Roll();
            int[] rolltwo = new int[2];
            rolltwo[0] = roll1st;
            rolltwo[1] = roll2nd;
            return rolltwo;
        }

    }
}
