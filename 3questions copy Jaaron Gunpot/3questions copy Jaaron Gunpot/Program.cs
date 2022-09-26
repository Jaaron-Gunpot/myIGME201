using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace _3questions_copy_Jaaron_Gunpot
{
    static internal class Program
    {


        static Timer fiveSec;
        static public void Main(string[] args)
        {
        begin:
            //if the time is finished or not
            bool timeOut = false;
            //to check if the response is a valid input
            bool qChosen = false;
            //hold number chosen for question
            string nChoice = "";
            string response = "";
            int nChosen = 0;
        //prompts for number of questions
        

            do
            {
                Console.Write("Choose your question (1-3): ");
                nChoice = Console.ReadLine();

                try
                {
                    nChosen = int.Parse(nChoice);
                    if (nChosen == 1 || nChosen == 2 || nChosen == 3)
                    {
                        qChosen = true;
                    }

                }
                catch
                {
                    qChosen = false;
                }

            } while (!qChosen);
            switch (nChosen)
            {
                case 1:
                    Console.WriteLine("What is your favorite color?");
                    break;
                case 2:
                    Console.WriteLine("What is the awnser to life, the universe and everything?");
                    break;
                case 3:
                    Console.WriteLine("What is the airspeed velocity of an unladen swallow?");
                    break;
            }
            while (!timeOut)
            {
                //picks from a set of three questions based on user input
                
                //has a 5 second timer
                fiveSec = new Timer(5000);
                //fiveSec.Elapsed+= new ElapsedEventHandler(timeUp);
                fiveSec.Start();
                fiveSec.Elapsed += delegate (object sender, ElapsedEventArgs e)
                {
                    //Console.WriteLine("");
                    Console.WriteLine("Your time is up!");
                    timeOut = true;
                    fiveSec.Stop();
                };
                response = Console.ReadLine();

                fiveSec.Stop();
                //checks if response is correct
                switch (nChosen)
                {
                    case 1:
                        if (response.ToLower() == "black" && !timeOut)
                        {
                            Console.WriteLine("Well Done!");
                        }
                        else if (response.ToLower() != "black" || timeOut)
                        {
                            Console.WriteLine("The awnser is: black");
                            timeOut = true;
                        }
                        break;
                    case 2:
                        Console.WriteLine("What is the awnser to life, the universe and everything?");
                        if (response.ToLower() == "42" && !timeOut)
                        {
                            Console.WriteLine("Well Done!");
                        }
                        else if (response.ToLower() != "42" || timeOut)
                        {
                            Console.WriteLine("The awnser is: 42");
                            timeOut = true;
                        }
                        break;
                    case 3:
                        Console.WriteLine("What is the airspeed velocity of an unladen swallow?");
                        break;
                }

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
        end:
            //asks the user if they want to play again
            Console.Write("Press Enter to Play Again");
            Console.ReadLine();
            //congratulates if answered correctly and provides awnser if wrong or out of time
            goto begin;

        }
    }
}
