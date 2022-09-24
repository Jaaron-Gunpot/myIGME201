using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace _3questions_copy_Jaaron_Gunpot
{
    static internal class Program
    {
        static bool timeOut=false;

        static Timer fiveSec;
        static void Main(string[] args)
        {
            //if the time is finished or not
            timeOut=false;
            //to check if the response is a valid input
            bool qChosen=false;
            //hold number chosen for question
            string nChoice = "";
            int nChosen=0;
        //prompts for number of questions
        begin:
            
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
            while (!timeOut)
            {
                Timer fiveSec = new Timer(5000);
                ElapsedEventHandler elapsedEventHandler = null;
                elapsedEventHandler = new ElapsedEventHandler(timeUp);
                fiveSec.Elapsed += elapsedEventHandler;
                //picks from a set of three questions based on user input
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
                //has a 5 second timer
                fiveSec.Start();
                string response = Console.ReadLine();
                fiveSec.Stop();
                //checks if response is correct
                
                /*switch (nChosen)
                {
                    case 1:
                        if (response.ToLower() == "black")
                        {
                            Console.WriteLine("Well Done!");
                        }else if(response.ToLower() != "black" || timeOut)
                        {
                            Console.WriteLine("The awnser is: black");
                        }
                        break;
                    case 2:
                        Console.WriteLine("What is the awnser to life, the universe and everything?");
                        break;
                    case 3:
                        Console.WriteLine("What is the airspeed velocity of an unladen swallow?");
                        break;
                }
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
          static void timeUp(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Times up!");
            timeOut = true;
        }  
    }
}
