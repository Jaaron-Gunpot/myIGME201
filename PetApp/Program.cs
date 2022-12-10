using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PetApp
{
    public abstract class Pet
    {
        private string name;
        public int age;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public abstract void Eat();
        public abstract void Play();
        public abstract void GoToVet();
        public Pet(string name, int age)
        {
            this.age = age;
            this.name = name;
        }
        public Pet() 
        {

        }
    }
    public class Pets
    {
        List<Pet> petList = new List<Pet>();
        public Pet this[int nPetEl]
        {
            get
            {
                Pet returnVal;
                try
                {
                    returnVal = (Pet)petList[nPetEl];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                // if the index is less than the number of list elements
                if (nPetEl < petList.Count)
                {
                    // update the existing value at that index
                    petList[nPetEl] = value;
                }
                else
                {
                    // add the value to the list
                    petList.Add(value);
                }
            }
        }

        public int Count
        {
            get
            {
                return this.petList.Count;
            }
        }
        public void Add(Pet pet)
        {
            this.petList.Add(pet);
        }
        public void Remove(Pet pet)
        {
            this.petList.Remove(pet);
        }
        public void RemoveAt(int petEI)
        {
            this.petList.RemoveAt(petEI);
        }
    }
    public interface IDog
    {
        void Eat();
        void Play();
        void Bark();
        void NeedWalk();
        void GoToVet();
    }
    public interface ICat
    {
        void Eat();
        void Play();
        void Scratch();
        void Purr();
    }
    public class Cat : Pet, ICat
    {
        public Cat()
        {

        }
        public override void Eat()
        {
            Console.WriteLine($"{Name}:Nom Nom Meow");
        }
        public override void Play()
        {
            //throw new NotImplementedException();
            Console.WriteLine($"{Name} started playing with a ball of yarn");
        }
        public override void GoToVet()
        {
            //throw new NotImplementedException();
            Console.WriteLine($"{Name} needs to go to the vet");
        }
        public void Scratch()
        {
            Console.WriteLine($"{Name} is using the scratch post");
        }
        public void Purr()
        {
            Console.WriteLine("PURR");
        }
        //the method that is used when eviction occurs 
        public void EvictReact()
        {

        }
    }
    public class Dog : Pet, IDog 
    {
        public Dog(string szLicense, string szName, int nAge) : base(szName, nAge)
        {
            this.license = szLicense;
            this.Name = szName;
            this.age = nAge;
        }
        public string license;
        public override void Eat()
        {
            Console.WriteLine(this.Name + ":Nom Nom Bark");
        }
        public override void Play()
        {
            //throw new NotImplementedException();
            Console.WriteLine(this.Name + " Wants to play fetch");
        }
        public override void GoToVet()
        {
            //throw new NotImplementedException();
            Console.WriteLine(this.Name + " vomited on the floor, I think he needs to go to the vet");
        }
        public void Bark()
        {
            Console.WriteLine(this.Name + " Bark Bark Bark");
        }
        public void NeedWalk()
        {
            Console.WriteLine(this.Name + " needs to go on a walk");
        }
        static public void EvictCat(object sender, ElapsedEventArgs e)
        {
            
        }
    }
    static internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Pets pets = new Pets();
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;
            //extra code
            Timer myTimer = new Timer(20000);
            myTimer.Elapsed += new ElapsedEventHandler(Dog.EvictCat);
            myTimer.Start();
            //Makes 50 actions 
            for (int i = 0; i < 50; ++i)
            {

                // 1 in 10 chance of adding an animal
                if (rand.Next(1, 11) == 1)
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        // add a dog
                        pets[i] = new Dog("122-728-2984", "Ruffles", 7);
                        
                    }
                    else
                    {
                        // else add a cat
                        cat = new Cat();
                        cat.Name = "Fluffers";
                        pets.Add(cat);
                        //((Pet)pets[i]).Name="Mittens";
                        //if(thisPet != null)
                        //{
                        //   thisPet.Name = "Mittens";
                        //}

                    }
                }
                else
                {
                    // choose a random pet from pets and choose a random activity for the pet to do
                    //if they don't exist yet just break with doing nothing
                    Pet randPet = pets[rand.Next(0, pets.Count)];
                    switch (rand.Next(1, 5))
                    {
                        case 1:
                            if (randPet == null)
                            {
                                break;
                            }
                            randPet.Eat();
                            break;
                        case 2:
                            if (randPet == null)
                            {
                                break;
                            }
                            randPet.Play();
                            break;
                        case 3:
                            if (randPet == null)
                            {
                                break;
                            }
                            randPet.GoToVet();
                            break;
                        case 4:
                            if (randPet == null)
                            {
                                break;
                            }
                            if (randPet is Cat)
                            {
                                ((Cat)randPet).Purr();
                            }
                            if (randPet is Dog)
                            {
                                ((Dog)randPet).Bark();
                            }
                            break;
                        case 5:
                            if (randPet == null)
                            {
                                break;
                            }
                            if (randPet is Cat)
                            {
                                ((Cat)randPet).Scratch();
                            }
                            if (randPet is Dog)
                            {
                                ((Dog)randPet).NeedWalk();
                            }
                            break;
                    }
                }
            }
        }
    }
}
