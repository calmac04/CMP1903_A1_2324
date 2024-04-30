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
            //program class that controls the menu operations
            //creates a new instance of stats
            Stats data = new Stats();
            //defaults the menuselect variable to be an unused number to allow for looping if an invalid input is given
            int menuselect = 5;
            //loops while exit is unselected
            while (menuselect != 0)
            {
                //ressets selection vairable to default
                menuselect = 5;
                //writes the menu options
                Console.WriteLine("menu");
                Console.WriteLine("1 - sevens out");
                Console.WriteLine("2 - 3 of a kind");
                Console.WriteLine("3 - stats");
                Console.WriteLine("4 - test");
                Console.WriteLine("0 - exit");
                //reads the user input and stores the string
                string selectstring = Console.ReadLine();
                //attempts to convert the input to an int
                Int32.TryParse(selectstring, out menuselect);
                //checks if the user input is a valid entry
                if (menuselect >= 5 || menuselect < 0)
                {
                    //if invalid inform the user
                    Console.WriteLine("please enter a valid response");
                }
                //if option 1 selected
                else if (menuselect == 1)
                {
                    //create a new instance of sevens out
                    SevensOut seven = new SevensOut();
                    //run the game and pass the stats instance
                    seven.Run(data);
                }
                //if option 2 selected
                else if (menuselect == 2)
                {
                    //create a new instance of three or more
                    ThreeOrMore three = new ThreeOrMore();
                    //run the game and pass the stats instance
                    three.Run(data);
                }
                //if option 3 selected
                else if (menuselect == 3)
                {
                    //display the stats
                    data.display();
                    //display the highscores
                    data.highscores();
                }
            }
        }
    }
}
