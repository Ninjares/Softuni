using System;

namespace Stealer
{
    class Program
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            Console.WriteLine(spy.StealFieldInfo("Hacker", "username"));
            Console.WriteLine(spy.GetAccessModifiers("Stealer.Hacker"));
            Console.WriteLine(spy.RevealPrivateMethods("Stealer.Hacker"));
            Console.WriteLine(spy.GettersAndSetters("Stealer.Hacker"));
        }
    }
}
