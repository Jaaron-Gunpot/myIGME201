using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_14
{
    internal class Program
    {
        public interface IFood
        {
            void Meal();
        }
        public class Mary : IFood
        {
            public void Meal()
            {
                Console.WriteLine("Mary eats Steak");
            }
        }
        public class Alexis : IFood
        {
            public void Meal()
            {
                Console.WriteLine("Alexis eats Dragons");
            }
        }
        static void Main(string[] args)
        {
            Mary mary = new Mary();
            Alexis alexis = new Alexis();
            MyMethod(alexis);
            MyMethod(mary);
        }
        public static void MyMethod(object myObject)
        {
            ((IFood)myObject).Meal();
        }
    }
}
