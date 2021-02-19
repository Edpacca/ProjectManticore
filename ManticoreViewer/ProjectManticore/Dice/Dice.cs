using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreViewer
{
    public struct Dice
    {
        public int Number { get; private set; }
        public int Type { get; private set; }
        public int Modifier { get; set; }

        public Dice(int type)
        {
            Number = 1;
            Type = type;
            Modifier = 0;
        }

        public Dice(int number, int type)
        {
            Number = number;
            Type = type;
            Modifier = 0;
        }

        public Dice(int number, int type, int modifier)
        {
            Number = number;
            Type = type;
            Modifier = modifier;
        }
    }
}
