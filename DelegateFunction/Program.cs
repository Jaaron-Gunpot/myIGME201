using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateFunction
{
    class Program
    {
        public delegate double MyRounder(double d, int n);
        static void Main(string[] args)
        {
            // create variable of delegate function type 
            MyRounder myRounder;

            // your code here
            myRounder = new MyRounder(Math.Round);
            myRounder = Math.Round;
            myRounder = delegate (double d, int n){return Math.Round(d, n);};
            myRounder = (double d, int n) =>{return Math.Round(d, n);};
            myRounder = (d, n) =>{return Math.Round(d, n);};
            myRounder = (d, n) => Math.Round(d, n);
            myRounder = (double d, int n) => Math.Round(d, n);
            Func<double, int, double> rounder = Math.Round;
            //rounder = (d, n) => (double)Math.Round(d, n);

            //Console.WriteLine(rounder(4.5642,1).ToString());
        }
    }

}
