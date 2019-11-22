using System;
using System.IO;
using System.Xml.Linq;

namespace XMLDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(File.ReadAllText(@"./../../../Library.xml"));
            XDocument document = XDocument.Load(@"./../../../Library.xml");
            document.Declaration.Version = "3.0";
            var elements = document.Root.Elements();
            foreach (var element in elements.Attributes())
                Console.WriteLine(element);
            document.Save(@"./../../../Library.xml");
            
            Console.WriteLine();
            
        }
    }
}
