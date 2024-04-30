using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Die
    {
        /*
         * this class is unchanged from the previous assessment
         */

        //Property
        //rolled value property to store what the die rolled
        private int rolledvalue;

        public int RolledValue
        {
            get {return rolledvalue;}
            set {rolledvalue = value;}
        }

        //Method
        //method randomly determines a number in the range 1 to 6 inclusive and returns the value generated
        public int Roll()
        {
            //create a new random class instance
            Random rnd = new Random();
            //generate a random number
            rolledvalue = rnd.Next(1, 7);
            //return the random number
            return rolledvalue;
        }


    }
}
