using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreViewer
{
    public class RollResult
    {
        public int Total { get; private set; }
        public List<int> Rolls { get; private set; }
        public string RollString { get; private set; }
        private bool _rolled;
        public DRollResult DRoll;

        public RollResult()
        {
            Rolls = new List<int>();
            DRoll = new DRollResult();
        }

        public RollResult(int total, int modifier, List<int> rolls)
        {
            Total = total;
            Rolls = rolls != null ? rolls : new List<int>();
        }

        public void Roll(Dice dice, IDiceRoller diceRoller)
        {
            _rolled = true;

            for (int i = 0; i < dice.Number; i++)
            {
                Rolls.Add(diceRoller.Roll(dice.Type));
                Total += Rolls[i];
            }

            Total += dice.Modifier;
            DRoll.RollResult = Total;
            WriteRollString(dice);
        }

        private void WriteRollString(Dice dice)
        {
            if (!_rolled)
                throw new NotImplementedException("Dice not rolled");

            string resultString = dice.Number + "d" + dice.Type + ": {";

            for (int i = 0; i < Rolls.Count; i++)
            {
                string result = Rolls[i] == dice.Type ? Rolls[i] + "!" : Rolls[i].ToString();
                resultString = i != Rolls.Count - 1 ? resultString + result + ", " : resultString + result;
            }

            RollString = resultString + " } +" + dice.Modifier + " = " + Total;
            DRoll.RollString = RollString;
        }
    }
}
