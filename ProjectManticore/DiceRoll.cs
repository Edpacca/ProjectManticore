using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManticore
{
    public class DiceRoll
    {
        public DiceRoll(byte numberOfDice, Dice dieType, byte modifier)
        {
            NumberOfDice = numberOfDice;
            DieType = dieType;
            Modifier = modifier;
        }

        public enum Dice
        {
            d4 = 4,
            d6 = 6,
            d8 = 8,
            d10 = 10,
            d12 = 12,
            d20 = 20
        }

        public Dice DieType { get; set; }
        public byte NumberOfDice { get; set; }
        public byte Modifier { get; set; }

        public string GetDiceString()
        {
            return NumberOfDice + "d" + DieType.ToString() + " +" + Modifier;
        }

        public static string DiceToString(byte numberOfDice, Dice dieType, byte modifier)
        {
            return numberOfDice + "d" + dieType.ToString() + " +" + modifier;
        }
    }
}
