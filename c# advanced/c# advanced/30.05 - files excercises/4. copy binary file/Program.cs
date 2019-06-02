using System;
using System.IO;

namespace copy_binary_file
{
    class Program
    {
        static void Main(string[] args)
        {
            string picPath = @"..\..\..\picc\63a.png";
            string picCopyPath = @"..\..\..\picc\63b(copy).png"; ;

            using(FileStream picreader = new FileStream(picPath, FileMode.Open))
            {
                using(FileStream picPainter = new FileStream(picCopyPath, FileMode.Create))
                {
                    while (true)
                    {
                        int offset = 0;
                        byte[] byteArray = new byte[4096];
                        int size = picreader.Read(byteArray, offset, byteArray.Length); //I read {size} amount of bytes
                        if (size == 0) break;
                        picPainter.Write(byteArray, offset, size);
                    }
                }
            }
        }
    }
}
