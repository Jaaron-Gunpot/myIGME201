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
        }
    }
}
