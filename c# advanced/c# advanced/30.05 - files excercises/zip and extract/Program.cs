using System;
using System.IO;
using System.IO.Compression;
namespace zip_and_extract
{
    class Program
    {
        static void Main(string[] args)
        {
            string picFolderPath = @"..\..copy binary file\picc\63a.png";
            //string targerPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "result.zip";
            string targerPath = @"..\..\..\result.zip";

            using(var archive = new ZipFile.Open(targerPath, ))

        }

    }
}


