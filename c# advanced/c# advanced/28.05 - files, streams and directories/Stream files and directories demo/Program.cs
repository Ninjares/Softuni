using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stream_files_and_directories_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                /*          What is a stream?              да можеш на парчета да прехвърляш файловете
                 * Streams are used to transfer data   (a sequence of bytes - not like a torrent) 
                 * We open streams to: -Read data, -Write data
                 * НАША ГРИЖА Е ДА СИ ЧИСТИМ СТРИЙМОВЕТЕ
                 * stream buffer - 2 pieces
                 * file size - 9 pieces
                 * position - marker (the start of the buffer) 
                 * The marker jumps to the position next to the end of the buffer
                 * 1 - open 
                 * 2 - read
                 * 3 - flush
                 * 4 - close
                 */
            }
            //using System.IO
            string filename = "yeet.txt";
            string pathname = "text";
            string filepath = Path.Combine(pathname, filename);
            var reader = new StreamReader(filepath, Encoding.GetEncoding(1251));
            using (reader)
            {
                int counter = 0;
                string line = reader.ReadLine();
                //using-a flushva
                using (var writer = new StreamWriter("text//succ.txt"))
                {
                    while (line != null)
                    {
                        if (counter % 2 == 1)
                        {
                            writer.WriteLine(line);
                            Console.WriteLine(line);
                        }

                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }

            //The System.IO.Stream class
            
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }

            string text = "Мемелица";
            var fileStream = new FileStream("C:\\Users\\mm1-ignis\\Desktop\\Softuni rep\\c# advanced\\c# advanced\\28.05 - files, streams and directories\\Stream files and directories demo\\text\\sftest.txt", FileMode.OpenOrCreate);

            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                fileStream.Write(bytes, 0, bytes.Length);
            }
            finally
            {
                fileStream.Close();
            }

             
            Console.ReadKey();
        }
    }
}
