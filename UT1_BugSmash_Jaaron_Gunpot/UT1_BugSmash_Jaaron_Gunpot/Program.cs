using System;

namespace UT1_BugSmash_Jaaron_Gunpot
{
    class Program
    {
        // Calculate x^y for y > 0 using a recursive function
        static void Main(string[] args)
        {
            string sNumber;
            int nX;
            //compile time error: missing semicolon
            //int nY
            int nY;
            int nAnswer;

            //compile time error: missing ""
            //Console.WriteLine(This program calculates x ^ y.);
            Console.WriteLine("This program calculates x ^ y.");

            do
            {
                Console.Write("Enter a whole number for x: ");
                //compile error: the sNumber is read but is never given a value
                //Console.ReadLine();
                sNumber =Console.ReadLine();
            } while (!int.TryParse(sNumber, out nX));

            do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
            }//logic error:is assigning value to nX instead of nY
            //while (int.TryParse(sNumber, out nX));
            //logic error:int.TryParse(sNumber, out nY) will only leave the loop if sNumber is not an int since it will return false which will leave the loop
            //while (int.TryParse(sNumber, out nY));
            while (!int.TryParse(sNumber, out nY));
            // compute the exponent of the number using a recursive function
            nAnswer = Power(nX, nY);

            //run-time error: missing $
            //Console.WriteLine("{nX}^{nY} = {nAnswer}");
            Console.WriteLine($"{nX}^{nY} = {nAnswer}");
        }

        //compile time error: missing static
        //int Power(int nBase, int nExponent)
        

        static int Power(int nBase, int nExponent)
        {
            int returnVal=0;
            int nextVal=0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                //logic error: anything multiplied by zero is zero
                //returnVal = 0;
                returnVal = 1;
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                //logic error: Says should be nExponent-1 but is nExponent+1 instead and causes infinite recursion
                //nextVal = Power(nBase, nExponent + 1);
                nextVal = Power(nBase, nExponent - 1);

                // multiply the base with all subsequent values
                returnVal = nBase * nextVal;
            }

            //compile time error: missing return
            //returnVal;
            return returnVal;
        }
    }
}

