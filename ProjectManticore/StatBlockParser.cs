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

            return parsedStats;

            //parsedStats.ChallengeRating = unparsedObject.Challenge;
            //parsedStats.ArmourClass = unparsedObject.ArmorClass;
            //parsedStats.AvgHitPoints = unparsedObject.HitPoints;
        }

        private void ParseChallengeRating(string unparsed)
        {
            string challengeRating = unparsed.Substring(0, unparsed.IndexOf(' '));
        }

    }
}
