namespace ConsoleApp
{
    using System;
    using CTF.Framework.TestRunner;

    public class Program
    {
        public static void Main(string[] args)
        {
            string assemblyPath = @".\..\..\..\..\Calculator.Tests\bin\Debug\netcoreapp3.0\Calculator.Tests.dll";
            Runner runner = new Runner();
            string result = runner.Run(assemblyPath);
            Console.WriteLine(result);
        }
    }
}
