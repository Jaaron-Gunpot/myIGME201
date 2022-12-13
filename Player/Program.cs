using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;
using System.IO;
using System.Xml.Linq;

namespace Player
{
    public class Player
    {
        public string player_name;
        public int level;
        public int hp;
        public string[] inventory = new string[] {"spear",
        "water bottle",
        "hammer",
        "sonic screwdriver",
        "cannonball",
        "wood",
        "Scooby snack",
        "Hydra",
        "poisonous potato",
        "dead bush",
        "repair powder"};
        public string license_key;
        private int saveSlot = 1;
        private Player()
        {

        }

        public void Save()
        {
            StreamWriter sw = new StreamWriter($"Profile{saveSlot}.JSON");
            sw.Write(JsonConvert.SerializeObject(playState));
            sw.Close();
            Console.WriteLine();
            StreamReader player = new StreamReader($"Profile{saveSlot}.JSON");
            string json = player.ReadToEnd();
            player.Close();
            Console.WriteLine(json);
            saveSlot++;
        }

        public string Load(int? slot =null)
        {
            StreamReader player = new StreamReader($"Profile{slot}.JSON");
            string json = player.ReadToEnd();
            player.Close();
            Console.WriteLine(json);
            return json;
        }
        private static Player playState = new Player();

        public static Player Get()
        {
            return playState;
        }
    }
    static internal class Program
    {
        static void Main(string[] args)
        {
            //object[][] list = new object[6][];

            //list = JsonConvert.DeserializeObject<object[][]>(json);
            //Console.WriteLine(Player.player.name);
            Player play = Player.Get();

            play.Load();

            play.level = 1;
            play.hp = 1;
            play.inventory.Append("Magic Cane");
            play.player_name = "Justin";
            play.license_key = "3418117664822410";

            play.Save();

            play.Load(1);
        }
    }
}
