using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitTst2_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Makes the List
            SortedList<string, DateTime> friendBirthdays
                = new SortedList<string, DateTime>();
            //Adds the items
            //DateTime(year,month,day)
            friendBirthdays.Add("Alexis Rhodes", new DateTime(1988,3,5));
            friendBirthdays.Add("Bruce Wayne", new DateTime(1915, 4, 7));
            friendBirthdays.Add("Mark Zuckerburg", new DateTime(1984, 5, 14));
            friendBirthdays.Add("Zane Truesdale", new DateTime(1986, 11, 1));
            friendBirthdays.Add("Seto Kaiba", new DateTime(1980, 10, 25));

            //prints to console from list
            foreach(KeyValuePair<string, DateTime> pair in friendBirthdays)
            {
                Console.WriteLine($"{pair.Key}'s birthday is {((DateTime)pair.Value).ToString("MM/dd/yyyy")}");
            }
        }
    }
}
