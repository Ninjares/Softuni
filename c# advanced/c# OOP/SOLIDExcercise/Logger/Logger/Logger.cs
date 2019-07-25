using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    
    class Logger:ILogger
    {
        private List<IAppender> appenders;

        public Logger(params IAppender[] appenderpars)
        {
            appenders = new List<IAppender>(appenderpars);
        }
        private void AppendAll(List<IAppender> appenders, string datetime, Level lvl, string msg)
        {
            foreach (IAppender appender in appenders)
                appender.AppendMessage(datetime, lvl, msg);
        }



        public void Info(string datetime, string msg)
        {
            AppendAll(appenders, datetime, Level.Info, msg);
        }
        public void Warning(string datetime, string msg)
        {
            AppendAll(appenders, datetime, Level.Warning, msg);
        }
        public void Error(string datetime, string msg)
        {
            AppendAll(appenders, datetime, Level.Error, msg);
        }
        public void Critical(string datetime, string msg)
        {
            AppendAll(appenders, datetime, Level.Critical, msg);
        }
        public void Fatal(string datetime, string msg)
        {
            AppendAll(appenders, datetime, Level.Fatal, msg);
        }
    }
}
