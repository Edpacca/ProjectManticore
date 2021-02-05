using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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

        public Monster(){}

        public Monster(dynamic jsonObject)
        {
            Name = jsonObject.name;
            Meta = jsonObject.meta;
            Languages = jsonObject.Languages;
            Senses = jsonObject.Senses;
            HitPoints = StatBlockParser.ParseHP(jsonObject.HitPoints);
            CurrentHitPoints = HitPoints;
            CurrentHPCount.Add(HitPoints);
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

        public event PropertyChangedEventHandler PropertyChanged;

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
    }
}
