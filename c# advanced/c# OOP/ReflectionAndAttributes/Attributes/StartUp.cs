using System;

namespace Attributes
{
    [Author("Ventsi")]
    public class StartUp
    {
        [Author("Cicana")]
        [Author("Gosho")]
        public static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
