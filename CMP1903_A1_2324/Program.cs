using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stats data = new Stats();
            int menuselect = 5;
            while (menuselect != 0)
            {
                menuselect = 5;
                Console.WriteLine("menu");
                Console.WriteLine("1 - sevens out");
                Console.WriteLine("2 - 3 of a kind");
                Console.WriteLine("3 - stats");
                Console.WriteLine("4 - test");
                Console.WriteLine("0 - exit");
                string selectstring = Console.ReadLine();
                Int32.TryParse(selectstring, out menuselect);
                if (menuselect >= 5 || menuselect < 0)
                {
                    Console.WriteLine("please enter a valid response");
                }
                else if (menuselect == 1)
                {
                    SevensOut seven = new SevensOut();
                    seven.Run(data);
                }
                else if (menuselect == 2)
                {
                    ThreeOrMore three = new ThreeOrMore();
                    three.Run(data);
                }
                else if (menuselect == 3)
                {
                    data.display();
                    data.highscores();
                }
            }
        }
    }
}
