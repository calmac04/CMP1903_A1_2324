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
        //here the main variables are created
        public int largestkey = 0;
        public int largestcount = 0;
        public int p1 = 0;
        public int p2 = 0;
        public void Run(Stats data) 
        {
            string select = "a";
            while (select != "y" && select != "n")
            {
                Console.WriteLine("play against pc y/n");
                select = Console.ReadLine();
                if (select == "y")
                {
                    aienabled = true;
                }
                else if (select == "n")
                {
                    aienabled = false;
                }
            }
            while (gameend == false)
            {
                largestkey = 0;
                largestcount = 0;
                if (player1 == true)
                {
                    Console.WriteLine("player 1's turn");
                    Check(Dice(5));
                    while (true)
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
                                player1 = false;
                                break;
                            }
                        }
                    }
                    Console.Write("score is ");
                    Console.WriteLine(p1);
                    if (p1 >= 20)
                    {
                        gameend = true;
                    }
                }
                else
                {
                    if (!aienabled) 
                    {
                        Console.WriteLine("player 2's turn");
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
                        }
                    }
                    else
                    {
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
                    }
                }
            }
            Console.WriteLine("game over");
            if (!aienabled)
            {
                if (p1 > p2)
                {
                    Console.WriteLine("player 1 wins");
                }
                else if (p1 < p2)
                {
                    Console.WriteLine("player 2 wins");
                }
                else
                {
                    Console.WriteLine("tie game");
                }
            }
            else
            {
                if (p1 > p2)
                {
                    Console.WriteLine("player wins");
                }
                else if (p1 < p2)
                {
                    Console.WriteLine("AI wins");
                }
                else
                {
                    Console.WriteLine("tie game");
                }
            }
            data.storethrees(p1, p2);
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
            Console.Write("your best group was ");
            Console.Write(largestcount);
            Console.Write(" ");
            Console.Write(largestkey);
            Console.WriteLine("'s");
        }
        public List<int> Testrun()
        {
            int pt = 0;
            List<int> testdata = new List<int>();
            int datacount = 1;
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
                testdata[datacount] = largestcount;
                datacount++;
                Console.Write("score is ");
                Console.WriteLine(p2);
                if (pt >= 20)
                {
                    gameend = true;
                }
            }
            testdata[0] = pt;
            return testdata;
        }
    }        
}
