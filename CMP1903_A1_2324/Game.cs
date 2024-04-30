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
        //game class that the other games are parented from
        //establishes the player turn gameend and aienabled variables used throughout the games to control the deciding functions of each game
        public bool player1 = true;
        public bool gameend = false;
        public bool aienabled = false;
        //main method used in sevens out
        public int[] Roll2()
        {
            //creates 2 dice objects
            Die Die1 = new Die();
            Die Die2 = new Die();
            //rolls one of the dice
            int roll1st = Die1.Roll();
            //waits a short delay to allow randomisation to change
            Thread.Sleep(100);
            //rolls the second die
            int roll2nd = Die2.Roll();
            //creates an int array to store the data
            int[] rolltwo = new int[2];
            //stores the data
            rolltwo[0] = roll1st;
            rolltwo[1] = roll2nd;
            //returns the rolls
            return rolltwo;
        }

    }
}
