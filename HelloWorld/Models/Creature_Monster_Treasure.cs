using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models
{

    public class Creature_Monster_Treasure
    {
        public Data data { get; set; }
    }
    
    public class Data
    {
        public string category { get; set; }
        public string[] common_locations { get; set; }
        public string description { get; set; }
        public string[] drops { get; set; }
        public int id { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public string cooking_effect { get; set; }
        public int hearts_recovered { get; set; }
    }

}
