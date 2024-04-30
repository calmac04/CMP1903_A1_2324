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
        //create a new instance of sevens and threes
        public SevensOut sevens = new SevensOut();
        public ThreeOrMore threes = new ThreeOrMore();
        //this method will test both games
        public void TestRun()
        {
            //write that testing for sevens has begun
            Console.WriteLine("testing start");
            Console.WriteLine("Testing sevens");
            //run test run for sevens and store the roll totals in a list with the first value being the final roll
            List<int> sevensdata = sevens.testrun();
            //check if the last value rolled is 7 to check if end conditions work
            Debug.Assert(sevensdata[0] == 7);
            //for every item in sevensdata
            foreach (int i in sevensdata)
            {
                //check if the total is between minimum and maximums
                Debug.Assert(i >=2 && i<=12);
            }

            //inform the user that threes is being tested
            Console.WriteLine("Testing threes");
            //testrun threes and store the number of duplicates for each turn and store the final score as the first value
            List<int> threesdata = threes.Testrun();
            //check if the end score is greater than 20 to see fi game ends correctly
            Debug.Assert(threesdata[0] >= 20);
            //create a variable to store the final score
            int testscore = 0;
            //store the final score
            testscore = threesdata[0];
            //remove the final score from the list
            threesdata.RemoveAt(0);
            //create a new score to recalculate
            int score = 0;
            //for every set of rolls recalculate thier score
            foreach (int i in threesdata)
            {
                //check the number of matching dice is between 1 and 5 inclusive
                Debug.Assert(i >= 1 && i <= 5);
                //if the number of matching dice is 3
                if (i == 3)
                {
                    //add 3 to the score
                    score += 3;
                }
                //if number of matching dice is 4
                else if (i == 4)
                {
                    //add 6 to the score
                    score += 6;
                }
                //if the number of matching dice is 5
                else if (i == 5)
                {
                    //add 12 to the score
                    score += 12;
                }
            }
            //write what the calculated and recalculated scores are
            Console.Write("game calculated score");
            Console.WriteLine(testscore);
            Console.Write("test calculated score");
            Console.WriteLine(score);
            //check that the scores match
            Debug.Assert(score == testscore);
            //inform the user that testing had ended
            Console.WriteLine("testing end");
        }
    }
}
