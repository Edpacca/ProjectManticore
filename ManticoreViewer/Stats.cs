using System.Collections.Generic;

namespace ManticoreViewer
{
    public class Stats
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public float ChallengeRating { get; set; }
        public int ArmourClass { get; set; }
        public int AvgHitPoints { get; set; }
        public string Speed { get; set; }

        public string ImgURL { get; set; }
        public string Actions { get; set; }

        public List<string> Modifiers { get; private set; }

        public void SetModifiers()
        {
            Modifiers = ParseModifiers();
        }

        private List<string> ParseModifiers()
        {
            List<string> modifiers = new List<string>();

            modifiers.Add(Utility.StringModifier(Strength));
            modifiers.Add(Utility.StringModifier(Dexterity));
            modifiers.Add(Utility.StringModifier(Constitution));
            modifiers.Add(Utility.StringModifier(Intelligence));
            modifiers.Add(Utility.StringModifier(Wisdom));
            modifiers.Add(Utility.StringModifier(Charisma));

            return modifiers;
        }
    }
}
