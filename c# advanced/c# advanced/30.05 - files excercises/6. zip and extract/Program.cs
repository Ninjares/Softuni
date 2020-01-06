using System;
using System.IO;
using System.IO.Compression;
namespace zip_and_extract
{
    class Program
    {
        static void Main(string[] args)
        {
            string picFolderPath = @"..\..\..\..\copy binary file\picc\63a.png";
            string targerPath = @"..\..\..\result.zip";

            using(var zip = ZipFile.Open(targerPath, ZipArchiveMode.Create)) //the archive needs to be deleted to run properly
            {
                zip.CreateEntryFromFile(picFolderPath, "63zip.png");
            }
        }

    }
}


