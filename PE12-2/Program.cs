using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassTestBed;

namespace PE12_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDerivedClass myDerived = new MyDerivedClass();
            Console.WriteLine(myDerived.GetString());
        }
    }
    public class MyDerivedClass : MyClass 
    {
        public override string GetString()
        {
            return base.GetString();
        }
    }

}
