using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        //Methods


        //to allow for single rolls a second method is used
        public void roll1()
        {
            //create a die
            Die Die1 = new Die();
            //roll the die
            Die1.Roll();
            //read the roll to the user
            Console.WriteLine("new roll");
            Console.WriteLine(Die1.rolledvalue);
            //increment the total accordingly
            sumtotal += Die1.rolledvalue;
            //read the new total to the user
            Console.WriteLine("new total");
            Console.WriteLine(sumtotal);
        }


    }
}
