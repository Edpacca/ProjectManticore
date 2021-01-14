using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManticore
{
    public class Roller : IDiceRoller
    {
        private Random _random = new Random();

        public int Roll(int diceType)
        {
            return _random.Next(1, diceType + 1);
        }
    }
}
