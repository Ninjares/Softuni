using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    class Smartphone:Browser, Phone
    {
        public void Call(string number)
        {
            bool real = true;
            foreach (char a in number)
                if (!char.IsDigit(a)) { real = false; break; }
            if (real) Console.WriteLine($"Calling... {number}");
            else Console.WriteLine("Invalid number!");
        }

        public void Browse(string website)
        {
            if(website.Any(c => char.IsDigit(c)))
                Console.WriteLine("Invalid URL!");
            else
            Console.WriteLine($"Browsing: {website}!");
        }
    }
}
