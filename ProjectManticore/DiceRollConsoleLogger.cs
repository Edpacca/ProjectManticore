using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManticore
{
    class DiceRollConsoleLogger : ILogger
    {
        public void LogString(string message)
        {
            Console.WriteLine(message);
        }

        public void LogValue(int value)
        {
            Console.WriteLine("Total: " + value);
        }
    }
}
