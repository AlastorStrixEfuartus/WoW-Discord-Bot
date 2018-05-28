using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfWarcraft_Bot.Data
{
    public class Creature
    {
        public int Entry { get; set; }
        public int ModelID1 { get; set; }
        public string Name { get; set; }
        public int minLevel { get; set; }
        public int maxLevel { get; set; }
        public string AIName { get; set; }
        public string ScriptName { get; set; }
    }
}
