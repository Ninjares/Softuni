using System;

namespace DeprecatedClass
{
    public class StartUp
    {
        public static void Main()
        {
            var privateObject = new PrivateObject(new Summator());
            Console.WriteLine(privateObject.Invoke("GetSum", 12, 13));

        }
    }
}