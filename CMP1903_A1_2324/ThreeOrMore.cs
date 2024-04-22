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
        public int largestkey = 0;
        public int largestcount = 0;
        public int p1 = 0;
        public void Run(Stats data) 
        {
            while (gameend == false)
            {
                if (player1 == true)
                {
                    Check(Dice(5));
                    Console.Write("your best group was ");
                    Console.Write(largestcount);
                    Console.Write(" ");
                    Console.Write(largestkey);
                    Console.WriteLine("'s");
                    while (player1 == true)
                    {

                        if (largestcount == 3)
                        {
                            p1 += 3;
                            player1 = false;
                            break;
                        }
                        else if (largestcount == 4)
                        {
                            p1 += 6;
                            player1 = false;
                            break;
                        }
                        else if (largestcount == 5)
                        {
                            p1 += 12;
                            player1 = false;
                            break;
                        }
                        else if (largestcount <= 1)
                        {
                            player1 = false;
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
                                Console.Write("your best group was ");
                                Console.Write(largestcount);
                                Console.Write(" ");
                                Console.Write(largestkey);
                                Console.WriteLine("'s");
                            }
                        }
                    }
                }
                Console.WriteLine("new player turn");
                Console.ReadLine();
            }
            Console.WriteLine("game over");
            Console.ReadLine();
        }

        private int[] Dice(int num)
        {
            int[] rolls = new int[5];
            for (int i = 0; i < num; i++)
            {
                Die Die = new Die();
                rolls[i] = Die.Roll();
                Thread.Sleep(100);
                Console.Write(rolls[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
            return rolls;
        }

        private void Check(int[] rolls)
        {
            var groups = rolls.GroupBy(v => v);
            foreach (var group in groups)
            {
                if (group.Count() > largestcount)
                {
                    largestcount = group.Count();
                    largestkey = group.Key;
                }
                else if (group.Count() == largestcount)
                {
                    if (group.Key > largestkey)
                    {
                        largestcount = group.Count();
                        largestkey = group.Key;
                    }
                }
            }

        }
    }
}
