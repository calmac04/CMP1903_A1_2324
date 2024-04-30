using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Xml.Schema;

namespace CMP1903_A1_2324
{
    internal class ThreeOrMore : Game
    {
        //this is the class that runs the three or more game
        //create the variables for largest key value largest number of mathing dice and the two player scores
        public int largestkey = 0;
        public int largestcount = 0;
        public int p1 = 0;
        public int p2 = 0;
        //the run method operates the main game
        public void Run(Stats data) 
        {
            //create a new selection variable to check if ai should be used
            string select = "a";
            //while a valid answer is not given
            while (select != "y" && select != "n")
            {
                //ask the user if they want ot play against ai
                Console.WriteLine("play against pc y/n");
                //read their response
                select = Console.ReadLine();
                //if they say yes
                if (select == "y")
                {
                    //enable ai
                    aienabled = true;
                }
                //if they say no
                else if (select == "n")
                {
                    //leave ai disabled
                    aienabled = false;
                }
            }
            //while the game is still going
            while (gameend == false)
            {
                //reset the largest key and count variables
                largestkey = 0;
                largestcount = 0;
                //if it is player 1s turn
                if (player1 == true)
                {
                    //write whos turn it is
                    Console.WriteLine("player 1's turn");
                    //call the check method passing it the dice 5 method (lower down in this class)
                    //this rolls 5 dice and checks if there are any matching dice and if so what are they
                    Check(Dice(5));
                    //loop until break
                    while (true)
                    {
                        //if 3 matching dice are found
                        if (largestcount == 3)
                        {
                            //add three to the score
                            p1 += 3;
                            //switch player turn
                            player1 = false;
                            //break from loop
                            break;
                        }
                        //if 4 matching dice are found
                        else if (largestcount == 4)
                        {
                            //add six to the score
                            p1 += 6;
                            //switch player turns
                            player1 = false;
                            //break from loop
                            break;
                        }
                        //if 5 matching dice are found
                        else if (largestcount == 5)
                        {
                            //add twelve to score
                            p1 += 12;
                            //switch player turn
                            player1 = false;
                            //break out of loop
                            break;
                        }
                        // if there are no matching dice
                        else if (largestcount <= 1)
                        {
                            //switch turn
                            player1 = false;
                            //break loop
                            break;
                        }
                        //otherwise there are 2 matching dice which requires a decision
                        else
                        {
                            //create a selection variable
                            int rerollselect = 0;
                            //write the options to the pl;ayer
                            Console.WriteLine("1 - reroll all");
                            Console.WriteLine("2 - reroll 3");
                            //read their response
                            string selectstring = Console.ReadLine();
                            //conver response to int
                            Int32.TryParse(selectstring, out rerollselect);
                            //if response invalid
                            if (rerollselect >= 3 || rerollselect <= 0)
                            {
                                //inform user of error
                                Console.WriteLine("please enter a valid response");
                            }
                            //otherwise if reroll all selected
                            else if (rerollselect == 1)
                            {
                                //write current operation
                                Console.WriteLine("rerolling");
                                //break from loop without switching turn
                                break;
                            }
                            //if reroll 3 selected
                            else
                            {
                                //create a list for new rolls
                                List<int> newrolls = new List<int>();
                                //store the current pair
                                int toadd = largestkey + 0;
                                //configure and default list to avoid errors
                                newrolls.Clear();
                                //add the old double to the list
                                newrolls.Add(toadd);
                                newrolls.Add(toadd);
                                //roll 3 dice
                                foreach (int item in Dice(3))
                                {
                                    //add each die to the new list
                                    newrolls.Add(item);
                                }
                                //remove erroneous zeroes to prevent errors
                                newrolls.Remove(0);
                                newrolls.Remove(0);
                                //create a new array to store the new set of dice
                                int[] redoarray = new int[5];
                                //add the new dice rolls to the new array
                                for (int i = 0; i < newrolls.Count; i++)
                                {
                                    redoarray[i] = newrolls[i];
                                }
                                //check the array for matching dice
                                Check(redoarray);
                                //switch player turn
                                player1 = false;
                                //break loop
                                break;
                            }
                        }
                    }
                    //write the players score
                    Console.Write("score is ");
                    Console.WriteLine(p1);
                    //if the score is greater than 20
                    if (p1 >= 20)
                    {
                        //end the game
                        gameend = true;
                        Console.WriteLine("player 1 wins wins");
                    }
                }
                //if it is not player 1s turn
                else
                {
                    //if ai is disabled
                    if (!aienabled) 
                    {
                        //this functions identically to player 1 just adding score to different places
                        Console.WriteLine("player 2's turn");
                        Check(Dice(5));
                        while (true)
                        {
                            if (largestcount == 3)
                            {
                                // add to player 2s score
                                p2 += 3;
                                //switch to player 1s turn
                                player1 = true;
                                break;
                            }
                            else if (largestcount == 4)
                            {
                                //add to player 2s score
                                p2 += 6;
                                //switch to player 1
                                player1 = true;
                                break;
                            }
                            else if (largestcount == 5)
                            {
                                //add to player 2
                                p2 += 12;
                                //switch to player 1
                                player1 = true;
                                break;
                            }
                            else if (largestcount <= 1)
                            {
                                //switch to player 1
                                player1 = true;
                                break;
                            }
                            else
                            {
                                int rerollselect = 0;
                                Console.WriteLine("1 - reroll all");
                                Console.WriteLine("2 - reroll 3");
                                string selectstring = Console.ReadLine();
                                Int32.TryParse(selectstring, out rerollselect);
                                if (rerollselect >= 3 || rerollselect <= 0)
                                {
                                    Console.WriteLine("please enter a valid response");
                                }
                                else if (rerollselect == 1)
                                {
                                    Console.WriteLine("rerolling");
                                    break;
                                }
                                else
                                {
                                    List<int> newrolls = new List<int>();
                                    int toadd = largestkey + 0;
                                    newrolls.Clear();
                                    newrolls.Add(toadd);
                                    newrolls.Add(toadd);
                                    foreach (int item in Dice(3))
                                    {
                                        newrolls.Add(item);
                                    }
                                    newrolls.Remove(0);
                                    newrolls.Remove(0);
                                    int[] redoarray = new int[5];
                                    for (int i = 0; i < newrolls.Count; i++)
                                    {
                                        redoarray[i] = newrolls[i];
                                    }
                                    Check(redoarray);
                                    //switch to player 1
                                    player1 = true;
                                    break;
                                }
                            }
                        }
                        //write player 2s score
                        Console.Write("score is ");
                        Console.WriteLine(p2);
                        //check if player 2 wins
                        if (p2 >= 20)
                        {
                            gameend = true;
                            Console.WriteLine("player 2 wins");
                        }
                    }
                    //if it si player 2s turn and ai is enabled
                    else
                    {
                        //again near identically aside from decision making in event of pairs
                        Console.WriteLine("AI's turn");
                        Check(Dice(5));
                        while (true)
                        {
                            if (largestcount == 3)
                            {
                                p2 += 3;
                                player1 = true;
                                break;
                            }
                            else if (largestcount == 4)
                            {
                                p2 += 6;
                                player1 = true;
                                break;
                            }
                            else if (largestcount == 5)
                            {
                                p2 += 12;
                                player1 = true;
                                break;
                            }
                            else if (largestcount <= 1)
                            {
                                player1 = true;
                                break;
                            }
                            else
                            {
                                //in the event of a pair always reroll the 3 as this is statistically most effective
                                List<int> newrolls = new List<int>();
                                int toadd = largestkey + 0;
                                newrolls.Clear();
                                newrolls.Add(toadd);
                                newrolls.Add(toadd);
                                foreach (int item in Dice(3))
                                {
                                    newrolls.Add(item);
                                }
                                newrolls.Remove(0);
                                newrolls.Remove(0);
                                int[] redoarray = new int[5];
                                for (int i = 0; i < newrolls.Count; i++)
                                {
                                    redoarray[i] = newrolls[i];
                                }
                                Check(redoarray);
                                player1 = true;
                                break;
                            }
                        }
                    }
                    Console.Write("score is ");
                    Console.WriteLine(p2);
                    if (p2 >= 20)
                    {
                        gameend = true;
                        Console.WriteLine("ai wins");
                    }
                }
            }
            //when the game ends inform the player
            Console.WriteLine("game over");
            //store the data for the game
            data.storethrees(p1, p2);
        }
        //this function rolls a variable number of dice
        private int[] Dice(int num)
        {
            //create a new int array to store dice
            int[] rolls = new int[5];
            //rn once per required dice
            for (int i = 0; i < num; i++)
            {
                //create a new die
                Die Die = new Die();
                //roll adn store the die
                rolls[i] = Die.Roll();
                //delay to reset randomisation
                Thread.Sleep(100);
                //write the value of the roll
                Console.Write(rolls[i]);
                Console.Write(" ");
            }
            //writeline for formatting
            Console.WriteLine();
            //return set of rolls
            return rolls;
        }
        //this method checks for matching dice in a set of data
        private void Check(int[] rolls)
        {
            //group data set by value and store the groups
            var groups = rolls.GroupBy(v => v);
            //for each group of data
            foreach (var group in groups)
            {
                //if the number of matching dice is greater than current best
                if (group.Count() > largestcount)
                {
                    //store the matching dice information
                    largestcount = group.Count();
                    largestkey = group.Key;
                }
                //if current group is tied for current best
                else if (group.Count() == largestcount)
                {
                    //compare die value and if better
                    if (group.Key > largestkey)
                    {
                        //store dice set
                        largestcount = group.Count();
                        largestkey = group.Key;
                    }
                }
            }
            //write the information about teh current best group
            Console.Write("your best group was ");
            Console.Write(largestcount);
            Console.Write(" ");
            Console.Write(largestkey);
            Console.WriteLine("'s");
        }
        //this method is used for testing and operates similar to the ai
        public List<int> Testrun()
        {
            //create a score variable and a list to store data values in
            int pt = 0;
            List<int> testdata = new List<int>();
            //make first value blank
            testdata.Add(0);
            while (!gameend)
            {
                Check(Dice(5));
                while (true)
                {
                    if (largestcount == 3)
                    {
                        pt += 3;
                        break;
                    }
                    else if (largestcount == 4)
                    {
                        pt += 6;
                        break;
                    }
                    else if (largestcount == 5)
                    {
                        pt += 12;
                        break;
                    }
                    else if (largestcount <= 1)
                    {
                        break;
                    }
                    else
                    {
                        List<int> newrolls = new List<int>();
                        int toadd = largestkey + 0;
                        newrolls.Clear();
                        newrolls.Add(toadd);
                        newrolls.Add(toadd);
                        foreach (int item in Dice(3))
                        {
                            newrolls.Add(item);
                        }
                        newrolls.Remove(0);
                        newrolls.Remove(0);
                        int[] redoarray = new int[5];
                        for (int i = 0; i < newrolls.Count; i++)
                        {
                            redoarray[i] = newrolls[i];
                        }
                        Check(redoarray);
                        break;
                    }
                }
                //at the end of every turn store the current matching dice
                testdata.Add(largestcount);
                Console.Write("score is ");
                Console.WriteLine(pt);
                if (pt >= 20)
                {
                    gameend = true;
                }
            }
            //make the first item of the data set be the calculated score
            testdata[0] = pt;
            //return data set
            return testdata;
        }
    }        
}
