using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateModifier
{
    class DateModifier
    {
        private DateTime start;
        private DateTime end;

        public DateModifier(string start, string end)
        {
            int[] first = start.Split().Select(int.Parse).ToArray();
            int[] second = end.Split().Select(int.Parse).ToArray();

            this.start = new DateTime(first[0], first[1], first[2]);
            this.end = new DateTime(second[0], second[1], second[2]);
            
        }

        public int returnDiff()
        {
            TimeSpan days = end.Date - start.Date;
            int toret = (int)days.TotalDays;
            if (toret < 0) return toret * -1;
            else return toret;
        }
    }
}
