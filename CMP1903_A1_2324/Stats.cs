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

        public void storesevens(int p1, int c1, int p2, int c2)
        {
            List<int> dataset = new List<int>();
            dataset.Add(p1);
            dataset.Add(c1);
            dataset.Add(p2);
            dataset.Add(c2);
            sevensstats.Add(dataset);
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
        }
    }
}
