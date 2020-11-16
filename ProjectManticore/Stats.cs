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
        public byte Strength { get; set; }
        public byte Dexterity { get; set; }
        public byte Constitution { get; set; }
        public byte Intelligence { get; set; }
        public byte Wisdom { get; set; }
        public byte Charisma { get; set; }
        public float ChallengeRating { get; set; }
        public byte ArmourClass { get; set; }
        public int AvgHitPoints { get; set; }

        public void PrintStats()
        {
            Console.Write("Name: ");
            Console.WriteLine(Name);
            Console.Write("STR: ");
            Console.WriteLine(Strength);
            Console.Write("DEX: ");
            Console.WriteLine(Dexterity);
            Console.Write("CON: ");
            Console.WriteLine(Constitution);
            Console.Write("INT: ");
            Console.WriteLine(Intelligence);
            Console.Write("WIS: ");
            Console.WriteLine(Wisdom);
            Console.Write("CHAR: ");
            Console.WriteLine(Charisma);
            Console.Write("AC: ");
            Console.WriteLine(ArmourClass);
            Console.Write("CR: ");
            Console.WriteLine(ChallengeRating);
            Console.Write("HP: ");
            Console.WriteLine(AvgHitPoints);
        }
    }
}
