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
            string sName;
            double dSalary = 30000;

            Console.WriteLine("What is your name?");
            sName = Console.ReadLine();
            if (GiveRaise(sName,ref dSalary))
            {
                Console.WriteLine("you got a raise");
            }
        }
        static bool GiveRaise(string name, ref double salary)
        {
            return true;
        }
    }
}
