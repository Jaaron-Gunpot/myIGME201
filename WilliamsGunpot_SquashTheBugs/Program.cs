using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamsGunpot_SquashTheBugs
{
    // Class Program
    // Author: Jaaron Williams Gunpot
    // Purpose: Bug Squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare string to hold all numbers
            //int i = 0 compile-time error missing semicolon
            //int i = 0; logic error should be double instead of int
            double i = 0;

            // declare string to hold all numbers
            string allNumbers = null;

            // loop through the numbers 1 through 10
            //for ( i = 1; i < 10; ++i ) logic error < should be <= so it can include 10
            for (i = 1; i <= 10; ++i)
            {
                // declare string to hold all numbers
                //string allNumbers = null; logic error would renull every time a new loop starts

                // output explanation of calculation
                //Console.Write(i + "/" + i - 1 + "="); compile time error missing ()
                Console.Write(i + "/" + (i - 1) + "=");

                // output the calculation based on the numbers
                Console.WriteLine(i / (i - 1));
                

                // concatenate each number to allNumbers
                //allNumbers += i + ""; Logic error should have "," to have better readability
                allNumbers += i + "" + ",";

                // increment the counter
                //i = i + 1; logic error is uneeded since the for loop inreses i already and would make i increase by 2 every loop instead of 1

                // output all numbers which have been processed
                //Console.WriteLine("These numbers have been processed: ", allNumbers); Logic error should be + instead of ,
                Console.WriteLine("These numbers have been processed: " + allNumbers);
            }

            // output all numbers which have been processed
            //Console.WriteLine("These numbers have been processed: " allNumbers); compile time error missing ","
            //Console.WriteLine("These numbers have been processed: ", allNumbers); compile time error allNumbers does not exist in ths context  
        }
    }
}

