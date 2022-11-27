using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE16
{
    public interface IMood
    {
        string Mood
        {
            get;
        }
    }
    public interface ITakeOrder
    {
        void TakeOrder();
    }
    public class Customer : IMood
    {
        public string name;
        public string creditCardNumber;
        public string Mood
        {
            get { return name; }
        }
    }
    public abstract class HotDrink
    {
        public bool instant;
        public bool milk;
        public byte sugar;
        public string size;
        Customer customer;

        public virtual AddSugar(byte amount)
        {

        }

    }
}
