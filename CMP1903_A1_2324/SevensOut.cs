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
            int p1 = 0;
            int p2 = 0;
            int c1 = 0;
            int c2 = 0;
            while (gameend == false)
            {
                if (player1 == true)
                {
                    c1 += 1;
                    int[] currentroll = Roll2();
                    if (currentroll[0] != currentroll[1])
                    {
                        foreach (int item in currentroll)
                        {
                            Console.Write(item);
                            Console.Write(" ");
                            p1 += item;
                        }
                    }
                    else
                        foreach (int item in currentroll)
                        {
                            Console.Write(item);
                            Console.Write(" ");
                            p1 += item * 2;
                        }
                    Console.WriteLine();
                    if (currentroll[0] + currentroll[1] == 7)
                    {
                        Console.WriteLine("seven rolled");
                        Console.Write("your total score is ");
                        Console.WriteLine(p1);
                        player1 = false;
                        if (aienabled == true)
                        {
                            Console.WriteLine("AI's Turn");
                        }
                        else
                        {
                            Console.WriteLine("Player 2's turn");
                        }
                    }
                }
                else
                {
                    
                    if (aienabled == true)
                    {
                        c2 += 1;
                        int[] currentroll = Roll2();
                        if (currentroll[0] != currentroll[1])
                        {
                            foreach (int item in currentroll)
                            {
                                Console.Write(item);
                                Console.Write(" ");
                                p2 += item;
                            }
                        }
                        else
                            foreach (int item in currentroll)
                            {
                                Console.Write(item);
                                Console.Write(" ");
                                p2 += item * 2;
                            }
                        Console.WriteLine();
                        if (currentroll[0] + currentroll[1] == 7)
                        {
                            Console.WriteLine("seven rolled");
                            Console.Write("AI total score is ");
                            Console.WriteLine(p2);
                            gameend = true;
                        }
                    }
                    else 
                    {
                        c2 += 1;
                        int[] currentroll = Roll2();
                        if (currentroll[0] != currentroll[1])
                        {
                            foreach (int item in currentroll)
                            {
                                Console.Write(item);
                                Console.Write(" ");
                                p2 += item;
                            }
                        }
                        else
                            foreach (int item in currentroll)
                            {
                                Console.Write(item);
                                Console.Write(" ");
                                p2 += item * 2;
                            }
                        Console.WriteLine();
                        if (currentroll[0] + currentroll[1] == 7)
                        {
                            Console.WriteLine("seven rolled");
                            Console.Write("Player 2 total score is ");
                            Console.WriteLine(p2);
                            gameend = true;
                        }
                    }
                    
                }
            }
            Console.WriteLine("game is over");
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
            data.storesevens(p1, c1, p2, c2);
        }

        public List<int> testrun()
        {
            int pt = 0;
            int wt = 0;
            int datacount = 1;
            List<int> testdata = new List<int>();
            while (gameend == false)
            {
                int[] currentroll = Roll2();
                testdata[datacount] = currentroll[0] + currentroll[1];
                datacount++;
                if (currentroll[0] != currentroll[1])
                {
                    foreach (int item in currentroll)
                    {
                        Console.Write(item);
                        Console.Write(" ");
                        pt += item;
                    }
                }
                else
                    foreach (int item in currentroll)
                    {
                        Console.Write(item);
                        Console.Write(" ");
                        pt += item * 2;
                    }
                if (currentroll[0] + currentroll[1] == 7)
                {
                    wt = currentroll[0] + currentroll[1];
                    gameend = true;
                }
            }
            testdata[0] = wt;
            return testdata;
        }
    }
}
