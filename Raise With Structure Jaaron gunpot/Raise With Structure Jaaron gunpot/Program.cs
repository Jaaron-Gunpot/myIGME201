using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raise_Jaaron_Gunpot
{
    static internal class Program
    {

        struct employee
        {
            public string sName;
            public double dSalary;
        }

        static void Main(string[] args)
        {
            employee employee = new employee();
            //prompts for name
            Console.WriteLine("What is your name?");

            employee.sName = Console.ReadLine();
            employee.dSalary = 30000;

            if (GiveRaise(employee))
            {
                employee.dSalary = employee.dSalary + 19999.00;
                Console.WriteLine("You got a raise, congrats");
                Console.WriteLine("Your Salary is now $" + employee.dSalary);
            }
            else
            {
                Console.WriteLine("I'm sorry, you didn't get a raise");
            }
        }
        //Author: Jaaron Gunpot
        //Purpose: check if its my name and give me a raise
        static bool GiveRaise(employee employee)
        {
            if (employee.sName.ToLower() == "jaaron")
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
