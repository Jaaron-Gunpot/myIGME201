using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raise_Jaaron_Gunpot
{
    static internal class Program
    {

        static void Main(string[] args)
        {
            //name declaration
            string sName;

            //salary declaration
            double dSalary = 30000;

            //prompts for name
            Console.WriteLine("What is your name?");

            sName = Console.ReadLine();

            if (GiveRaise(sName,ref dSalary))
            {
                dSalary = dSalary+19999.00;
                Console.WriteLine("You got a raise, congrats");
                Console.WriteLine("Your Salary is now $"+dSalary);
            }
            else
            {
                Console.WriteLine("I'm sorry, you didn't get a raise");
            }
        }
        //Author: Jaaron Gunpot
        //Purpose: check if its my name and give me a raise
        static bool GiveRaise(string name, ref double salary)
        {
            if (name.ToLower() == "jaaron")
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
