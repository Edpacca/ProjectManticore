using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManticoreViewer
{
    public static class Utility
    {
        public static int CalculateModifier (int abilityScore)
        {
            return (int)((float)(abilityScore - 10) / 2);
        }

        public static string StringModifier(int abilityScore)
        {
            if (abilityScore == 0)
                return "";

            int modifier = CalculateModifier(abilityScore);
            return modifier == 0 ? "+0" : modifier > 0 ? "+" + modifier : modifier.ToString();
        }
    }
}
