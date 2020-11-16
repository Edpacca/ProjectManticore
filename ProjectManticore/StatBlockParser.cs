using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ProjectManticore
{
    public class StatBlockParser
    {
        public List<Stats> ParseObjects(dynamic unparsedObjects)
        {
            List<Stats> parsedObjects = new List<Stats>();
            foreach (var unparsedObject in unparsedObjects)
            {
                parsedObjects.Add(ParseObject(unparsedObject));
            }

            return parsedObjects;
        }

        private Stats ParseObject(dynamic unparsedObject)
        {
            Stats parsedStats = new Stats();
            parsedStats.Name = unparsedObject.name;
            parsedStats.Strength = (byte)unparsedObject.STR;
            parsedStats.Dexterity = (byte)unparsedObject.DEX;
            parsedStats.Constitution = (byte)unparsedObject.CON;
            parsedStats.Intelligence = (byte)unparsedObject.INT;
            parsedStats.Wisdom = (byte)unparsedObject.WIS;
            parsedStats.Charisma = (byte)unparsedObject.CHA;
            parsedStats.ChallengeRating = ParseChallengeRating(unparsedObject.Challenge);
            parsedStats.ArmourClass = ParseAC(unparsedObject.ArmorClass);
            parsedStats.AvgHitPoints = ParseHP(unparsedObject.HitPoints);

            return parsedStats;
        }

        private float ParseChallengeRating(dynamic unparsed)
        {
            string unparsedString = unparsed.ToString();
            string challengeRatingString = unparsedString.Substring(0, unparsedString.IndexOf(' '));
            float challengeRating;

            if (challengeRatingString.Contains('/'))
            {
                string[] CR = challengeRatingString.Split("/");
                challengeRating = (float)(Convert.ToDouble(CR[0]) / Convert.ToDouble(CR[1]));
            }
            else
                challengeRating = (float)(Convert.ToInt16(challengeRatingString));

            return challengeRating;  
        }

        private byte ParseAC(dynamic unparsed)
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

        private int ParseHP(dynamic unparsed)
        {
            string unparsedString = unparsed.ToString();
            string HPString = unparsedString.Substring(0, unparsedString.IndexOf(' '));
            return Convert.ToInt32(HPString);
        }

    }
}
