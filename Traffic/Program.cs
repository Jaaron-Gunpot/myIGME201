using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars;

namespace Traffic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPassengerCarrier passengerCarrier;
            PassengerTrain passengerTrain = new PassengerTrain();
            //passengerCarrier = PassengerTrain passengerCarrier1;
            passengerCarrier = passengerTrain;
            AddPassenger(passengerCarrier);
            _424DoubleBogey bogey = new _424DoubleBogey();
            //doesn't work
            AddPassenger(bogey);

        }
        static void AddPassenger(IPassengerCarrier ThisVehicle)
        {
            ThisVehicle.LoadPassenger();
            Console.WriteLine(ThisVehicle.ToString());
        }
    }
}
