using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Stats
    {
        //create some 2 dimensional lists to store the statistics for each game
        public List<List<int>> sevensstats = new List<List<int>>();
        public List<List<int>> threesstats = new List<List<int>>();
        //this method stores a sevens game
        public void storesevens(int p1, int c1, int p2, int c2)
        {
            //make an empty list to store data in
            List<int> dataset = new List<int>();
            //add the data from the game to that  list
            dataset.Add(p1);
            dataset.Add(c1);
            dataset.Add(p2);
            dataset.Add(c2);
            //add the new list to the main data list
            sevensstats.Add(dataset);
        }
        //this method stores threes games
        public void storethrees(int p1, int p2)
        {
            //make a new list
            List<int> dataset = new List<int>();
            //store the game stats in the list
            dataset.Add(p1);
            dataset.Add(p2);
            //add the list to the main list
            threesstats.Add(dataset);
        }
        //this method displays the entire stats files
        public void display()
        {
            //write information to the player about what is being display and how it is formatted
            Console.WriteLine("displaying stats");
            Console.WriteLine("sevens out games");
            Console.WriteLine("player1 score; player 1 roll count; player 2 score; player 2 roll count");
            //start a game counter
            int gamecount = 0;
            //for every sevens game
            foreach (List<int> item1 in sevensstats) 
            {
                //increment game counter
                gamecount++;
                //write the game number
                Console.Write("game ");
                Console.WriteLine(gamecount);
                //for every data point this game
                foreach (int item2 in  item1)
                {
                    //write the datapoint
                    Console.Write(item2);
                    Console.Write(";");
                }
                //write a blank line for formatting
                Console.WriteLine();
            }
            //inform the user abou the next data set
            Console.WriteLine("three or more games");
            Console.WriteLine("player1 score; player 2 score");
            //reset the game counter
            gamecount = 0;
            //for every threes game
            foreach (List<int> item1 in threesstats)
            {
                //increment gamecounter
                gamecount++;
                //write the game number
                Console.Write("game ");
                Console.WriteLine(gamecount);
                //for every datapoint this game
                foreach (int item2 in item1)
                {
                    //write the datapoint
                    Console.Write(item2);
                    Console.Write(";");
                }
                //write a blank line for formatting
                Console.WriteLine();
            }
        }
        //this method writes the highscores for both gametypes
        public void highscores()
        {
            //if there are no sevens games
            if (sevensstats.Count == 0) 
            {
                //write that there is no data
                Console.WriteLine("no sevens out scores recorded");
            }
            //if there are sevens games
            else
            {
                //set a new blank highscore
                int sevenshs = 0;
                //for every game in the sevens list
                foreach (List<int> item1 in sevensstats)
                {
                    //if player 1s score is better than the high score
                    if (item1[0] > sevenshs)
                    {
                        //save it as the high score
                        sevenshs = item1[0];
                    }
                    //otherwise if player 2s score is better than the high score
                    else if (item1[2] > sevenshs)
                    {
                        //save it as the new high score
                        sevenshs = item1[2];
                    }
                }
                //write what the high score is
                Console.Write("sevens out high score is ");
                Console.WriteLine(sevenshs);
            }
            //if there are no threes games
            if (threesstats.Count == 0)
            {
                //write that there are no threes games
                Console.WriteLine("no three or more scores recorded");
            }
            //otherwise if there are threes games
            else
            {
                //create a new blank high score
                int threeshs = 0;
                //for every game in the threes list
                foreach (List<int> item1 in threesstats)
                {
                    // if player 1s score is better than the high score
                    if (item1[0] > threeshs)
                    {
                        //save it as a new high score
                        threeshs = item1[0];
                    }
                    //otherwise if player 2s score is better than the high score
                    else if (item1[1] > threeshs)
                    {
                        //save it as the new high score
                        threeshs = item1[1];
                    }
                }
                //write what the high score is
                Console.Write("three or more high score is ");
                Console.WriteLine(threeshs);
            }
        }
    }
}
