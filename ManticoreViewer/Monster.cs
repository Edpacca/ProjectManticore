using System.Collections.Generic;

namespace ManticoreViewer
{
    public class Monster
    {
        public AbilityScores AbilityScores { get; private set; }
        public List<string> AbilityModifiers { get; private set; } = new List<string>();

        public Monster(AbilityScores abilityScores)
        {
            AbilityScores = abilityScores;
        }

        private void ParseModfifiers(AbilityScores abilityScores)
        {
            AbilityModifiers.Add(Utility.StringModifier(abilityScores.Strength));
            AbilityModifiers.Add(Utility.StringModifier(abilityScores.Dexterity));
            AbilityModifiers.Add(Utility.StringModifier(abilityScores.Constitution));
            AbilityModifiers.Add(Utility.StringModifier(abilityScores.Intelligence));
            AbilityModifiers.Add(Utility.StringModifier(abilityScores.Wisdom));
            AbilityModifiers.Add(Utility.StringModifier(abilityScores.Charisma));
        }
    }
}
