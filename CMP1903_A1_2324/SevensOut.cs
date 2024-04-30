using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class SevensOut : Game
    {
        //this method runs the game 
        public void Run(Stats data)
        {
            //first the game needs to determine whether there is a second player or not
            //selection variable is made
            string select = "a";
            //while there is an invalid selection
            while (select != "y" && select != "n")
            {
                //ask the user if they want to play against an ai
                Console.WriteLine("play against pc y/n");
                //store their response
                select = Console.ReadLine();
                //check what their response is
                if (select == "y")
                {
                    //if yes enable ai
                    aienabled = true;
                }
                else if (select == "n") 
                { 
                    //if no disable ai
                    aienabled = false;
                }
            }
            //declare the main score and counter variables
            int p1 = 0;
            int p2 = 0;
            int c1 = 0;
            int c2 = 0;
            //while the game is running
            while (gameend == false)
            {
                //if it is player 1s turn
                if (player1 == true)
                {
                    //increment player turn counter by 1
                    c1 += 1;
                    //create the players die rolls
                    int[] currentroll = Roll2();
                    //if the player has not rolled doubles
                    if (currentroll[0] != currentroll[1])
                    {
                        //for each roll
                        foreach (int item in currentroll)
                        {
                            //print the value of the roll
                            Console.Write(item);
                            Console.Write(" ");
                            //add the rolled number to the players score
                            p1 += item;
                        }
                    }
                    //if the player did roll doubles
                    else
                    {
                        //for both rolls
                        foreach (int item in currentroll)
                        {
                            //read out the number rolled
                            Console.Write(item);
                            Console.Write(" ");
                            //add double the roll
                            p1 += item * 2;
                        }
                    }
                    //write a new line for formatting
                    Console.WriteLine();
                    //if the total of the rolls is seven
                    if (currentroll[0] + currentroll[1] == 7)
                    {
                        //write what has happened to the player along with their final score
                        Console.WriteLine("seven rolled");
                        Console.Write("your total score is ");
                        Console.WriteLine(p1);
                        //switch to the other players turn
                        player1 = false;
                        //if the player is against an ai
                        if (aienabled == true)
                        {
                            //write that it is the ais turn
                            Console.WriteLine("AI's Turn");
                        }
                        //if the player is against another player
                        else
                        {
                            //write that it is the second players turn
                            Console.WriteLine("Player 2's turn");
                        }
                    }
                }
                //if it isnt the 1st players turn
                else
                {
                    //the following code functions near identically to the first players code with the exception of it adding score to a different total
                    //if the ai is eneabled
                    if (aienabled == true)
                    {
                        //increment player 2s turn counter
                        c2 += 1;
                        //roll 2 dice and store them
                        int[] currentroll = Roll2();
                        //if the player hasnt rolled doubles
                        if (currentroll[0] != currentroll[1])
                        {
                            //for both dice
                            foreach (int item in currentroll)
                            {
                                //write the roll to the player
                                Console.Write(item);
                                Console.Write(" ");
                                //store the roll
                                p2 += item;
                            }
                        }
                        //if the player did roll doubles
                        else
                        {
                            //for every dice
                            foreach (int item in currentroll)
                            {
                                //write the roll to the player
                                Console.Write(item);
                                Console.Write(" ");
                                //add double the roll to the score
                                p2 += item * 2;
                            }
                        }
                        //write a new line for formatting
                        Console.WriteLine();
                        //if the player rolled a seven
                        if (currentroll[0] + currentroll[1] == 7)
                        {
                            //display what has happened to the user and their score
                            Console.WriteLine("seven rolled");
                            Console.Write("AI total score is ");
                            Console.WriteLine(p2);
                            //end the game
                            gameend = true;
                        }
                    }
                    //if another player is playing
                    else 
                    {
                        //increment player turn counter
                        c2 += 1;
                        //roll 2 dice and save the rolls
                        int[] currentroll = Roll2();
                        //if the rolls arent doubles
                        if (currentroll[0] != currentroll[1])
                        {
                            //for every die
                            foreach (int item in currentroll)
                            {
                                //write the rolled value
                                Console.Write(item);
                                Console.Write(" ");
                                //increment the players score
                                p2 += item;
                            }
                        }
                        //if the rolls are doubles
                        else
                        {
                            //for both dice
                            foreach (int item in currentroll)
                            {
                                //print the roll value
                                Console.Write(item);
                                Console.Write(" ");
                                //add double the value
                                p2 += item * 2;
                            }
                        }
                        //write a blank line for formatting
                        Console.WriteLine();
                        //if the total is 7
                        if (currentroll[0] + currentroll[1] == 7)
                        {
                            //write what has occured
                            Console.WriteLine("seven rolled");
                            Console.Write("Player 2 total score is ");
                            Console.WriteLine(p2);
                            //end the game
                            gameend = true;
                        }
                    }
                    
                }
            }
            //write that the game is over
            Console.WriteLine("game is over");
            //if the player was against a person
            if (!aienabled)
            {
                //if player1 beat player 2
                if (p1 > p2)
                {
                    //write player 1 won
                    Console.WriteLine("player 1 wins");
                }
                //if player 2 won
                else if (p1 < p2)
                {
                    //write player 2 won
                    Console.WriteLine("player 2 wins");
                }
                //if the game is tied
                else
                {
                    //write that the game is tied
                    Console.WriteLine("tie game");
                }
            }
            //if the player played against ai
            else
            {
                //if the player beat the ai
                if (p1 > p2)
                {
                    //write that the player won
                    Console.WriteLine("player wins");
                }
                //if the ai won
                else if (p1 < p2)
                {
                    //write that the ai won
                    Console.WriteLine("AI wins");
                }
                //if the game was a tie
                else
                {
                    //write that the game was a tie
                    Console.WriteLine("tie game");
                }
            }
            //store the data for the game
            data.storesevens(p1, c1, p2, c2);
        }
        //this method runs a streamlined version of the game for testing purposes
        public List<int> testrun()
        {
            //set the score winning total and data count to default along with making a list to store the data in
            int pt = 0;
            int wt = 0;
            List<int> testdata = new List<int>();
            testdata.Add(0);
            //while the game is running
            while (gameend == false)
            {
                //roll 2 dice and store them
                int[] currentroll = Roll2();
                //store the total of the rolls
                testdata.Add(currentroll[0] + currentroll[1]);
                //if the rolls arent doubles
                if (currentroll[0] != currentroll[1])
                {
                    //for both dice
                    foreach (int item in currentroll)
                    {
                        //print the roll value
                        Console.Write(item);
                        Console.Write(" ");
                        //add their values to the score
                        pt += item;
                    }
                }
                //if the rolls are doubles
                else
                {
                    //for each die
                    foreach (int item in currentroll)
                    {
                        //print the roll value
                        Console.Write(item);
                        Console.Write(" ");
                        //add double the value to the score
                        pt += item * 2;
                    }
                }
                //write a new line for formatting
                Console.WriteLine();
                //if the current total is 7
                if (currentroll[0] + currentroll[1] == 7)
                {
                    //save current total as winning total
                    wt = currentroll[0] + currentroll[1];
                    //end the game
                    gameend = true;
                }
            }
            //store the winning total in teh first index
            testdata[0] = wt;
            //return the data array
            return testdata;
        }
    }
}
