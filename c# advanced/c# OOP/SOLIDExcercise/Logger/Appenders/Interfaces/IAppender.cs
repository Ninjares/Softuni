using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    interface IAppender
    {
        void AppendMessage(string datetime, Level level, string msg);
    }
}
