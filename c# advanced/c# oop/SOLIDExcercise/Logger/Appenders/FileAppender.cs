using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    class FileAppender : AbstractAppender
    {
        public FileAppender(ILayout layout) : base(layout)
        {
            var file = new FileStream(@"..\..\..\log.txt", FileMode.Create); //OperOrCreate vs. Append?
            file.Close();
        }
        
        public override void AppendMessage(string datetime, Level level, string msg)
        {
            using(var dispFS = new FileStream(@"..\..\..\log.txt", FileMode.Append))
            {
                using(var dispwriter = new StreamWriter(dispFS))
                {
                    dispwriter.WriteLine(base.ReturnMsg(datetime, level, msg));
                }
            }
        }
    }
}
