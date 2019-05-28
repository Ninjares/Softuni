using System;
using System.IO;

namespace fstream_excercise
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream inputFile = new FileStream(@"files\\input.txt", FileMode.OpenOrCreate))
            {
                long size = inputFile.Length;
                long partSize = (long)Math.Ceiling((double)size / 4);
                byte[] buffer = new byte[partSize];

                for(int i=0; i<4; i++)
                {
                    using (var outputFile = new FileStream($"files\\yeee {i + 1} eeet.txt", FileMode.Create))
                    {
                        int readedBytes = inputFile.Read(buffer, 0, buffer.Length);
                        outputFile.Write(buffer, 0, readedBytes);
                    }
                }
            }
                Console.WriteLine("Hello World!");
        }
    }
}
