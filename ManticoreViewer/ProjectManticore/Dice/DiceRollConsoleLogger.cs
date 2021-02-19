using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreViewer
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
