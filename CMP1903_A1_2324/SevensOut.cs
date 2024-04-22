﻿using System;
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
                    foreach (int item in currentroll)
                    {
                        Console.Write(item);
                        Console.Write(" ");
                        p1 += item;
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
                        foreach (int item in currentroll)
                        {
                            Console.Write(item);
                            Console.Write(" ");
                            p2 += item;
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
                        foreach (int item in currentroll)
                        {
                            Console.Write(item);
                            Console.Write(" ");
                            p2 += item;
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
                else
                {
                    Console.WriteLine("player 2 wins");
                }
            }
            else
            {
                if (p1 > p2)
                {
                    Console.WriteLine("player wins");
                }
                else
                {
                    Console.WriteLine("AI wins");
                }
            }
            data.storesevens(p1, c1, p2, c2);
        }
    }
}
