using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace unitTst2_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList<(string, int), double> avgRainfall = new SortedList<(string, int), double>();
            // where the index key fields are string = country name and int = year

            // add a row for USA/2017
            avgRainfall[("USA", 2017)] = 32.21;

            // access the SortedList via the tuple
            //Console.WriteLine(avgRainfall[("USA", 2017)]);

            //Given the formula z = 4y3 + 2x2 - 8w + 7 write the code for a 
            //SortedList<> based on the tuple(double, double, double) 
            //representing w, x and y.Use the necessary for () loops to store the 
            //values of z(which would also be a double) for the 
            //following ranges of w, x and y using the tuple as the index key.
            //You must round w, x and y to 1 decimal place, and round z to 3 decimal places:
            //-2 <= w <= 0 in 0.2 increments
	        //-1 <= y <= 1 in 0.1 increments
	        //0 <= x <= 4 in 0.1 increments.
            SortedList<(double,double,double),double> keyValuePairs = new SortedList<(double,double,double),double>();
            double xValue;
            double yValue;
            double wValue;
            //fix xValue not starting at 0
            for(xValue = 0; xValue <= 4; xValue += 0.1)
            {
                for (yValue = -1; yValue <= 1; yValue += 0.1)
                {
                    for (wValue = -2; wValue <= 0; wValue += 0.2)
                    {
                        yValue = Math.Round(yValue,1);
                        xValue = Math.Round(xValue, 1);
                        wValue = Math.Round(wValue, 1);
                        keyValuePairs[(xValue, yValue, wValue)] = Math.Round((Math.Pow(yValue, 3) * 4) + (Math.Pow(xValue, 2) * 2) - (8 * wValue) + 7, 3);
                        Console.WriteLine($"x:{xValue},y:{yValue},w:{wValue}=>z:{keyValuePairs[(xValue, yValue, wValue)]}");
                    }
                }
            }
            
        }
    }
}
