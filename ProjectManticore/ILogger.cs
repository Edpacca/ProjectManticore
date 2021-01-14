using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManticore
{
    public interface ILogger
    {
        void LogString(string message);
        void LogValue(int value);
    }
}
