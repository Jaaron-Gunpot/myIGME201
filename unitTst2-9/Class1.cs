using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace unitTst2_9
{
    public abstract class Player
    {

        public string handedness = "right";
        public string name;
        public abstract int Defense
        {
            get;
        }

        public abstract void Dribble();
        public virtual void Shoot()
        {
            Console.WriteLine($"{this.name} pulls up for the shot");
        }

    }
    public interface ISneakers
    {
        string Squeak(string brand);
    }
    public interface IBall
    {
        void Bounce();
        string Type(string brand);
    }
    public class Andre_Drummond : Player, ISneakers
    {
        Random rand = new Random();

        public override int Defense {
            get { return rand.Next(90, 99); }
        }
        public override void Dribble()
        {
            Console.WriteLine("Andre Drummond can't dribble");
        }
        public string Squeak(string brand)
        {
            if ("converse" == brand.ToLower())
            {
                return "Those terrible shoes in Andre's feet";
            }
            return $"{brand} squeaking on the court";
        }
    }
    public class Steph_Curry : Player, ISneakers, IBall 
    {
        Random rand = new Random();

        public override int Defense
        {
            get { return rand.Next(70, 90); }
        }
        public override void Dribble()
        {
            Console.WriteLine("Steph with the handles");
        }
        public string Squeak(string brand)
        {
            if ("nike" == brand.ToLower())
            {
                return "Those terrible shoes in Steph's feet";
            }
            if ("underarmor"== brand.ToLower())
            {
                return "Steph is wearin his signature shoes";
            }
            return $"Steph is wearing {brand}'s, what a traitor";
        }
        public string Type(string brand)
        {
            if (brand.ToLower() != "spalding")
            {
                return "what is that?";
            }
            else
            {
                return "normal";
            }
        }
        public void Bounce()
        {
            int randNumb=rand.Next(1, 3);
            if (randNumb == 2)
            {
                Console.WriteLine($"{Type("Splading")} bouncing on the court");
            }
            else
            {
                Console.WriteLine($"{Type("Wilson")} bouncing on the court, I guess");
            }
            
        }
    }
}
