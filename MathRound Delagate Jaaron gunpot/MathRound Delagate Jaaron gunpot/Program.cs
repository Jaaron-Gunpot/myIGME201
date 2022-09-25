using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathRound_Delagate_Jaaron_gunpot
{
    /// delegate steps
    /// 1. define the delegate method data type based on the method signature
    ///         delegate double MathFunction(double n1, double n2);
    /// 2. declare the delegate method variable
    ///         MathFunction processDivMult;
    /// 3. point the variable to the method that it should call
    ///         processDivMult = new MathFunction(Multiply);
    /// 4. call the delegate method / add the delegate method to the object's event handler
    ///         nAnswer = processDivMult(n1, n2);
    ///         timer.Elapsed += TimesUp;
    delegate double myRound(double x, int y);
    internal class Program
    {
        static void Main(string[] args)
        {
            myRound round;

            round = delegate (double x, int y)
            {
                return Math.Round(x, y);
            };
            round = new myRound(Math.Round);
            round = (x, y) =>
            {
                return Math.Round(x, y);
            };
            round = (double x, int y) =>
            {
                return Math.Round(x, y);
            };
            round = Math.Round;
        }
    }
}
