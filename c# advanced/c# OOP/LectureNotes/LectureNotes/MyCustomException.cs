using System;
using System.Collections.Generic;
using System.Text;

namespace LectureNotes
{
    class MyCustomException:Exception
    {
        public MyCustomException(string msg) : base(msg)
        {

        }
    }
}
