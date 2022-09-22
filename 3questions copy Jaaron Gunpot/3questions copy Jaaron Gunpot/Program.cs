using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3questions_copy_Jaaron_Gunpot
{
    static internal class Program
    {
        static void Main(string[] args)
        {
            //to check if the response is a valid input
            bool qChosen=false;
            //hold number chosen for question
            string nChoice = "";
            int nChosen=0;
            //prompts for number of questions
            do
            {
                Console.Write("Choose your question (1-3): ");
                nChoice=Console.ReadLine();
                try
                {
                    nChosen=int.Parse(nChoice);
                    if(nChosen==1|| nChosen == 2|| nChosen == 3)
                    {
                        qChosen = true;
                    }
                    
                }
                catch
                {
                    qChosen=false;
                }

            }while (!qChosen);

            //picks from a set of three questions based on user input
            switch (nChosen)
            {
                case 1:

                    break;
            }
            //has a 5 second timer
            //congratulates if answered correctly and provides awnser if wrong or out of time
            //asks the user if they want to play again

        /*
         * test code
         * start:
         *  string test;
         *  test=Console.ReadLine();
         *  if (test.ToLower() == "carrot")
         *  {
         *      Console.WriteLine("restart");
         *      goto start;
         *  }
         *  else
         *  {
         *      Console.WriteLine("Potato");
         *  }
         */

        }
    }
}
