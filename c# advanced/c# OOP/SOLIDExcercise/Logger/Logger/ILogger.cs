using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    interface ILogger
    {
        void Info(string datetime, string msg);
        void Warning(string datetime, string msg);
        void Error(string datetime, string msg);
        void Critical(string datetime, string msg);
        void Fatal(string datetime, string msg);
    }
}
