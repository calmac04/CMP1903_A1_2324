using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Stats
    {
        public List<List<int>> sevensstats = new List<List<int>>();
        public List<List<int>> threesstats = new List<List<int>>();

        public void storesevens(int p1, int c1, int p2, int c2)
        {
            List<int> dataset = new List<int>();
            dataset.Add(p1);
            dataset.Add(c1);
            dataset.Add(p2);
            dataset.Add(c2);
            sevensstats.Add(dataset);
        }

        public void storethrees(int p1, int p2)
        {
            List<int> dataset = new List<int>();
            dataset.Add(p1);
            dataset.Add(p2);
            threesstats.Add(dataset);
        }

        public void display()
        {
            Console.WriteLine("displaying stats");
            Console.WriteLine("sevens out games");
            Console.WriteLine("player1 score; player 1 roll count; player 2 score; player 2 roll count");
            int gamecount = 0;
            foreach (List<int> item1 in sevensstats) 
            {
                gamecount++;
                Console.Write("game ");
                Console.WriteLine(gamecount);
                foreach (int item2 in  item1)
                {
                    Console.Write(item2);
                    Console.Write(";");
                }
                Console.WriteLine();
            }
            Console.WriteLine("three or more games");
            Console.WriteLine("player1 score; player 2 score");
            gamecount = 0;
            foreach (List<int> item1 in threesstats)
            {
                gamecount++;
                Console.Write("game ");
                Console.WriteLine(gamecount);
                foreach (int item2 in item1)
                {
                    Console.Write(item2);
                    Console.Write(";");
                }
                Console.WriteLine();
            }
        }

        public void highscores()
        {
            if (sevensstats.Count == 0) 
            {
                Console.WriteLine("no sevens out scores recorded");
            }
            else
            {
                int sevenshs = 0;
                foreach (List<int> item1 in sevensstats)
                {
                    if (item1[0] > sevenshs)
                    {
                        sevenshs = item1[0];
                    }
                    else if (item1[2] > sevenshs)
                    {
                        sevenshs = item1[2];
                    }
                }
                Console.Write("sevens out high score is ");
                Console.WriteLine(sevenshs);
            }

            if (threesstats.Count == 0)
            {
                Console.WriteLine("no three or more scores recorded");
            }
            else
            {
                int threeshs = 0;
                foreach (List<int> item1 in threesstats)
                {
                    if (item1[0] > threeshs)
                    {
                        threeshs = item1[0];
                    }
                    else if (item1[1] > threeshs)
                    {
                        threeshs = item1[1];
                    }
                }
                Console.Write("three or more high score is ");
                Console.WriteLine(threeshs);
            }
        }
    }
}
