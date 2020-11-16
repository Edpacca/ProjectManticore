using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManticoreViewer
{
    public class Stats
    {
        public string Name { get; set; }
        public byte Strength { get; set; }
        public byte Dexterity { get; set; }
        public byte Constitution { get; set; }
        public byte Intelligence { get; set; }
        public byte Wisdom { get; set; }
        public byte Charisma { get; set; }
        public float ChallengeRating { get; set; }
        public byte ArmourClass { get; set; }
        public int AvgHitPoints { get; set; }
        public string Speed { get; set; }

        public string ImgURL { get; set; }
    }
}
