using System;
using System.Collections.Generic;

namespace ManticoreViewer
{
    public class StatBlockParser
    {
        public List<Stats> ParseObjects(dynamic unparsedObjects)
        {
            List<Stats> parsedObjects = new List<Stats>();

            foreach (var unparsedObject in unparsedObjects)
                parsedObjects.Add(new Stats(unparsedObject));

            return parsedObjects;
        }

        public static float ParseChallengeRating(dynamic unparsed)
        {
            string unparsedString = unparsed.ToString();
            string challengeRatingString = unparsedString.Substring(0, unparsedString.IndexOf(' '));
            float challengeRating;

            if (challengeRatingString.Contains("/"))
            {
                string[] CR = challengeRatingString.Split('/');
                challengeRating = (float)(Convert.ToDouble(CR[0]) / Convert.ToDouble(CR[1]));
            }
            else
                challengeRating = (float)(Convert.ToInt16(challengeRatingString));

            return challengeRating;  
        }

        public static byte ParseAC(dynamic unparsed)
        {
            string unparsedString = unparsed.ToString();

            try
            {
                byte AC = Convert.ToByte(unparsedString);
                return AC;
            }
            catch (Exception)
            {
                string ACString = unparsedString.Substring(0, unparsedString.IndexOf(' '));
                return Convert.ToByte(ACString);
            }
        }

        public static int CalculateModifier(int abilityScore)
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
