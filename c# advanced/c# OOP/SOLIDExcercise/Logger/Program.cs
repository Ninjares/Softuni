using System;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            ILayout simpleLayout = new SimpleLayout();
            ILayout xmlLayout = new XmlLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            IAppender fileappender = new FileAppender(xmlLayout);
            Logger logger = new Logger(consoleAppender, fileappender);
            logger.Info(DateTime.Now.ToString(), "All systems nominal, b0ss");
            logger.Warning(DateTime.Now.ToString(), "We might fuck up");
            logger.Error(DateTime.Now.ToString(), "You stalled the reactor");
            logger.Critical(DateTime.Now.ToString(), "We blew a control system tank");
            logger.Fatal("26/4/1986 01:26:45 AM", "THE CORE EXPLODED");
            
        }
    }
}
