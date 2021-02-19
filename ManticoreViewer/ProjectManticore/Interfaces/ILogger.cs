using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreViewer
{
    public interface ILogger
    {
        void LogString(string message);
        void LogValue(int value);
    }
}
