using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace unitTst2_4
{
    public abstract class Phone
    {
        private string phoneNumber;
        public string address;
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
        }
        public abstract void Connect();
        public abstract void Disconnect();
    }
    public interface IPhoneInterface
    {
        void Answer();
        void MakeCall();
        void HangUp();
    }
    public class RotaryPhone:Phone, IPhoneInterface
    {
        public void Answer()
        {

        }
        public void MakeCall()
        {

        }
        public void HangUp()
        {

        }
        public override void Connect()
        {

        }
        public override void Disconnect()
        {

        }
    }
    public class PushButtonPhone : Phone,IPhoneInterface
    {
        public void Answer()
        {

        }
        public void MakeCall()
        {

        }
        public void HangUp()
        {

        }
        public override void Connect()
        {
            
        }
        public override void Disconnect()
        {
           
        }
    }
    public class Tardis : RotaryPhone
    {
        private bool sonicScrewdriver;
        private byte whichDrWho;
        private string femaleSideKick;
        public double exteriorSurfaceArea;
        public double interiorVolume;
        
        public byte WhichDrWho
        {
            get { return whichDrWho; }
        }
        public string FemaleSideKick
        {
            get { return femaleSideKick; }
        }
        public void TimeTravel()
        {

        }
        public static bool operator <(Tardis tardis1,Tardis tardis2)
        {
            if (tardis1.WhichDrWho == 10)
            {
                return false;
            }
            else if (tardis2.WhichDrWho == 10)
            {
                return true;
            }
            else
            {
                return tardis1.WhichDrWho < tardis2.WhichDrWho;
            }
        }
        public static bool operator >(Tardis tardis1, Tardis tardis2)
        {
            if (tardis1.WhichDrWho == 10)
            {
                return true;
            }
            else if (tardis2.WhichDrWho == 10)
            {
                return false;
            }
            else
            {
                return tardis1.WhichDrWho > tardis2.WhichDrWho;
            }
        }
        public static bool operator <=(Tardis tardis1, Tardis tardis2)
        {
            if (tardis1.WhichDrWho == 10)
            {
                return false;
            }
            else if (tardis2.WhichDrWho == 10)
            {
                return true;
            }
            else
            {
                return tardis1.WhichDrWho <= tardis2.WhichDrWho;
            }
        }
        public static bool operator >=(Tardis tardis1, Tardis tardis2)
        {
            if (tardis1.WhichDrWho == 10)
            {
                return true;
            }
            else if (tardis2.WhichDrWho == 10)
            {
                return false;
            }
            else
            {
                return tardis1.WhichDrWho >= tardis2.WhichDrWho;
            }
        }
        public static bool operator ==(Tardis tardis1, Tardis tardis2)
        {
            return tardis1.WhichDrWho == tardis2.WhichDrWho;
        }
        public static bool operator !=(Tardis tardis1, Tardis tardis2)
        {
            return tardis1.WhichDrWho != tardis2.WhichDrWho;
        }
    }
    public class PhoneBooth : PushButtonPhone
    {
        private bool superMan;
        public double costPerCall;
        public bool phoneBook;
        public void OpenDoor()
        {

        }
        public void CloseDoor()
        {

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Tardis tardis = new Tardis();
            PhoneBooth phoneBooth = new PhoneBooth();
            UsePhone(tardis);
            UsePhone(phoneBooth);
        }
        static void UsePhone(object obj)
        {
            if(obj is Tardis)
            {
                ((Tardis)obj).TimeTravel();
            }
            if(obj is PhoneBooth)
            {
                ((PhoneBooth)obj).OpenDoor();
            }
        }
    }
}
