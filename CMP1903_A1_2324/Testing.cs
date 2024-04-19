using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Testing
    {
        /*
         * This class should test the Game and the Die class.
         * Create a Game object, call the methods and compare their output to expected output.
         * Create a Die object and call its method.
         * Use debug.assert() to make the comparisons and tests.
         */

        public Game game = new Game();
        //Method
        //creates and tests the dice code and the game code
        public void TestRun()
        {
            //instantiate a game and pull the returned data from it
            int[] testdata = game.Roll3();
            //inform the player of the current test step
            Console.WriteLine("test game run");
            //instantiate a new die
            Die testDie = new Die();
            //roll the test die
            testDie.Roll();
            //inform the user of the current test step
            Console.WriteLine("test die run");
            //debug test the die roll to ensure it is within bounds
            Debug.Assert(testDie.Roll() > 0 && testDie.Roll() < 7);
            //pull the sum total from the test data
            int data1 = testdata[0];
            //check total is within bounds
            Debug.Assert(data1 > 2 && data1 <19);
            //inform user of the current test step
            Console.WriteLine("test game sum run");
        }
    }
}
