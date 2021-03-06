﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ManticoreViewer
{
    public class Monster : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
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
        public List<int> CurrentHPCount { get; set; } = new List<int>();
        public int Number { get; set; } = 1;
        public string Meta { get; set; }
        public string Senses { get; set; }
        public string Languages { get; set; }
        public string DamageResistances { get; set; }
        public string DamageImmunities { get; set; }
        public string ConditionImmunities { get; set; }
        public string SavingThrows { get; set; }
        public string Skills { get; set; }
        public string LegendaryActions { get; set; }
        public Dictionary<string, string> Actions { get; set; }
        public List<string> ActionNames { get; set; }
        public List<string> ActionValues { get; set; }
        public Dictionary<string, string> Traits { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Monster()
        {
        }

        public Monster(dynamic jsonObject)
        {
            Name = jsonObject.name;
            Meta = jsonObject.meta;
            Languages = jsonObject.Languages == "--" ? null : jsonObject.Languages;
            Senses = jsonObject.Senses;

            HitPoints = StatBlockParser.ParseHP(jsonObject.HitPoints);
            ChallengeRating = StatBlockParser.ParseChallengeRating(jsonObject.Challenge);
            ArmourClass = StatBlockParser.ParseAC(jsonObject.ArmorClass);

            CurrentHitPoints = HitPoints;
            CurrentHPCount.Add(HitPoints);

            Speed = jsonObject.Speed;
            DamageResistances = jsonObject.Damage_Resistances;
            DamageImmunities = jsonObject.Damage_Immunities;
            ConditionImmunities = jsonObject.Condition_Immunities;
            SavingThrows = jsonObject.SavingThrows;
            Skills = jsonObject.Skills;

            ParseActions(jsonObject);

            Strength = (byte)jsonObject.STR;
            Dexterity = (byte)jsonObject.DEX;
            Constitution = (byte)jsonObject.CON;
            Intelligence = (byte)jsonObject.INT;
            Wisdom = (byte)jsonObject.WIS;
            Charisma = (byte)jsonObject.CHA;

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

        public void AddInstance()
        {
            CurrentHPCount.Add(HitPoints);
            Number = CurrentHPCount.Count();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Number)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentHPCount)));
        }

        public void RemoveInstance()
        {
            if (Number == 1)
                return;
            else
            {
                CurrentHPCount.RemoveAt(Number - 1);
                Number = CurrentHPCount.Count();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Number)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentHPCount)));
            }
        }

        private string StripHtmlTags(string input)
        {
            return input == null ? "" : Regex.Replace(input, @"<[^>]*>", "");
        }

        private Dictionary<string, string> ParseHtmlActions(string input)
        {
            var dictionary = new Dictionary<string, string>();
            var actions = Regex.Split(input, "<p><em><strong>");

            foreach (var action in actions)
            {
                if (!string.IsNullOrEmpty(action))
                {
                    try
                    {
                        var kvp = Regex.Split(action, @"</strong></em>");
                        dictionary.Add(StripHtmlTags(kvp[0]), StripHtmlTags(kvp[1]));
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            return dictionary;
        }

        private void ParseHtmlActionLists(string input)
        {
            var actions = Regex.Split(input, "<p><em><strong>");

            foreach (var action in actions)
            {
                if (!string.IsNullOrEmpty(action))
                {
                    try
                    {
                        var kvp = Regex.Split(action, @"</strong></em>");
                        ActionNames.Add(StripHtmlTags(kvp[0]));
                        ActionValues.Add(StripHtmlTags(kvp[1]));
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void ParseActions(dynamic jsonObject)
        {
            ActionNames = new List<string>();
            ActionValues = new List<string>();
            if (jsonObject.Actions != null)
                ParseHtmlActionLists((string)jsonObject.Actions);

            //if (jsonObject.Actions != null)
            //    Actions = ParseHtmlActions((string)jsonObject.Actions);

            //if (jsonObject.Traits != null)
            //    Traits = ParseHtmlActions((string)jsonObject.Traits);
        }

    }
}
