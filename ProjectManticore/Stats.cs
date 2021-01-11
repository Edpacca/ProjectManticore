using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManticore
{
    public class Stats
    {
        public string Name { get; set; }
        public string HitPoints { get; set; }
        public byte ArmourClass { get; set; }
        public byte Strength { get; set; }
        public byte Dexterity { get; set; }
        public byte Constitution { get; set; }
        public byte Intelligence { get; set; }
        public byte Wisdom { get; set; }
        public byte Charisma { get; set; }
        public float ChallengeRating { get; set; }

        public Stats(){}

        public Stats(dynamic jsonObject)
        {
            Name = jsonObject.name;
            HitPoints = jsonObject.HitPoints;
            Strength = (byte)jsonObject.STR;
            Dexterity = (byte)jsonObject.DEX;
            Constitution = (byte)jsonObject.CON;
            Intelligence = (byte)jsonObject.INT;
            Wisdom = (byte)jsonObject.WIS;
            Charisma = (byte)jsonObject.CHA;
            ChallengeRating = StatBlockParser.ParseChallengeRating(jsonObject.Challenge);
            ArmourClass = StatBlockParser.ParseAC(jsonObject.ArmorClass);
        }
    }
}
