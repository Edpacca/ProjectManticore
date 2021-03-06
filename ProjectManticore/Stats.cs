﻿using System;
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
        public string Speed { get; set; }
        public byte ArmourClass { get; set; }
        public byte Strength { get; set; }
        public byte Dexterity { get; set; }
        public byte Constitution { get; set; }
        public byte Intelligence { get; set; }
        public byte Wisdom { get; set; }
        public byte Charisma { get; set; }
        public float ChallengeRating { get; set; }
        public string ImgURL { get; set; }
        public List<string> Modifiers { get; private set; }

        public Stats(){}

        public Stats(dynamic jsonObject)
        {
            Name = jsonObject.name;
            HitPoints = jsonObject.HitPoints;
            Speed = jsonObject.Speed;
            Strength = (byte)jsonObject.STR;
            Dexterity = (byte)jsonObject.DEX;
            Constitution = (byte)jsonObject.CON;
            Intelligence = (byte)jsonObject.INT;
            Wisdom = (byte)jsonObject.WIS;
            Charisma = (byte)jsonObject.CHA;
            ChallengeRating = StatBlockParser.ParseChallengeRating(jsonObject.Challenge);
            ArmourClass = StatBlockParser.ParseAC(jsonObject.ArmorClass);
            ImgURL = jsonObject.img_url;
            SetModifiers();
        }

        public void SetModifiers()
        {
            Modifiers = ParseModifiers();
        }

        private List<string> ParseModifiers()
        {
            List<string> modifiers = new List<string>();

            modifiers.Add(StatBlockParser.StringModifier(Strength));
            modifiers.Add(StatBlockParser.StringModifier(Dexterity));
            modifiers.Add(StatBlockParser.StringModifier(Constitution));
            modifiers.Add(StatBlockParser.StringModifier(Intelligence));
            modifiers.Add(StatBlockParser.StringModifier(Wisdom));
            modifiers.Add(StatBlockParser.StringModifier(Charisma));

            return modifiers;
        }
    }
}
