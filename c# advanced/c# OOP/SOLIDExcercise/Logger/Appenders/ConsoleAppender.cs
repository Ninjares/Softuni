using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    class ConsoleAppender : AbstractAppender
    {
       
        public ConsoleAppender(ILayout layout):base(layout)
        {

        }
        public override void AppendMessage(string datetime, Level level, string msg)
        {
            Console.WriteLine(base.ReturnMsg(datetime, level, msg));
        }
    }
}
