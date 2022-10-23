using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unitTst2_9;

namespace UnitTst2_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Andre_Drummond andre = new Andre_Drummond();
            Steph_Curry steph_ = new Steph_Curry();
            MyMethod(steph_);
            MyMethod(andre);
            void MyMethod(object obj)
            {
                Console.WriteLine(((ISneakers)obj).Squeak("underarmor"));
                Console.WriteLine(((ISneakers)obj).Squeak("nike"));
            }
        }
    }
}
