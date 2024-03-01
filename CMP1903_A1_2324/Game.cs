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

        public int SumTotal = 0;
        //Methods
        //rolls 3 dice sums them and returns the data generated for the testing class to use
        public int[] Roll3()
        {
            //create a new die 
            Die Die1 = new Die();
            //roll the die
            Die1.Roll();
            //wait 1 thousandth of a second to allow device clock to change to allow for multiple random numbers
            Thread.Sleep(1);
            //repeat for second die
            Die Die2 = new Die();
            Die2.Roll();
            Thread.Sleep(1);
            //repeat for third die minus the delay as it is unnecissary 
            Die Die3 = new Die();
            Die3.Roll();
            //save the rolled values as variables for easier usage
            int dice1 = Die1.RolledValue;
            int dice2 = Die2.RolledValue;
            int dice3 = Die3.RolledValue;
            //display the rolled numbers to the user
            Console.WriteLine("rolls");
            Console.WriteLine(dice1);
            Console.WriteLine(dice2);
            Console.WriteLine(dice3);
            //calculate a total for the rolls
            SumTotal += Die1.RolledValue + Die2.RolledValue + Die2.RolledValue;
            //display the total to the user 
            Console.WriteLine("total of rolls");
            Console.WriteLine(SumTotal);
            //compile the rolls and and total for the testing data
            int[] answers = {SumTotal, dice1, dice2, dice3 };
            //return the data
            return answers;
        }

        //to allow for single rolls a second method is used
        public void Roll1()
        {
            //create a die
            Die Die1 = new Die();
            //roll the die
            Die1.Roll();
            //read the roll to the user
            Console.WriteLine("new roll");
            Console.WriteLine(Die1.RolledValue);
            //increment the total accordingly
            SumTotal += Die1.RolledValue;
            //read the new total to the user
            Console.WriteLine("new total");
            Console.WriteLine(SumTotal);
        }


    }
}
