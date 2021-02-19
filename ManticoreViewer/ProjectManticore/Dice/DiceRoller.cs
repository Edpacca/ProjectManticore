using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ManticoreViewer
{
    public class DiceRoller
    {
        public List<RollResult> RollResults { get; private set; }
        private Roller _roller;

        public DiceRoller()
        {
            RollResults = new List<RollResult>();
            _roller = new Roller();
        }

        public int RollDice(Dice dice, ILogger logger)
        {
            RollResult roll = new RollResult();

            roll.Roll(dice, _roller);
            RollResults.Add(roll);

            logger.LogString(roll.RollString);
            logger.LogValue(roll.Total);

            return roll.Total;
        }

        public DRollResult RollDiceInForm(Dice dice)
        {
            RollResult roll = new RollResult();

            roll.Roll(dice, _roller);
            RollResults.Add(roll);

            //MessageBox.Show(roll.RollString);

            return roll.DRoll;
        }

        public DRollResult OnDiceRolled(object source, DiceEventArgs diceEvent)
        {
             return RollDiceInForm(diceEvent.Dice);
        }
    }
}
