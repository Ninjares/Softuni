using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    abstract class AbstractAppender:IAppender
    {
        
        private ILayout layout;

        public AbstractAppender(ILayout layout)
        {
            this.layout = layout;
        }

        protected string ReturnMsg(string Datetime, Level level, string msg)
        {
            return String.Format(layout.LayoutFormat, Datetime, level, msg);
        }

        public abstract void AppendMessage(string datetime, Level level, string msg);
    }
}
