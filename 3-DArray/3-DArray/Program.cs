using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_DArray
{
    delegate double myRound(double x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            {

                myRound round;

                round = new myRound(Math.Round);

                double x = 0;
                double y = 0;
                double z = 0;

                int nX = 0;
                int nY = 0;

                // we declare our 3 dimensional array to hold:
                //        21 values of x
                //        41 values of y for each value of x
                //        3 values for each data point: the x, y and z
                double[,,] zFunc = new double[21, 41, 3];

                for (x = -1; x <= 1; x += 0.1, nX++)
                {
                    x = round(x, 1);

                    // start with the 0'th "y" bucket for this value of x
                    nY = 0;

                    for (y = 0; y <= 4; y += 0.1, ++nY)
                    {
                        y = round(y, 1);

                        z = 4 * Math.Pow(y, 3) + 2 * Math.Pow(x, 2) - 8 * x + 7;

                        z = round(z, 3);

                        zFunc[nX, nY, 0] = x;
                        zFunc[nX, nY, 1] = y;
                        zFunc[nX, nY, 2] = z;

                        Console.WriteLine($"x = {zFunc[nX, nY, 0]}  y = {zFunc[nX, nY, 1]}   z = {zFunc[nX, nY, 2]}");
                    }
                }
            }
        }
    }
}