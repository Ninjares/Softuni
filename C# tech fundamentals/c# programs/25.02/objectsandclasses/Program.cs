using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace objectsandclasses
{
    class Program
    {



        static DateTime day = new DateTime(1997,5,15);

        //variables inside structs and classes are private by default:
        struct birthday
        {
            int day;
            int month;
            int year;
        };
        /// <summary>
        /// Personal date of best memes
        /// </summary>
        class Date
        {
            
            public int year;
            public int month;
            public int day;
            /// <summary>
            /// Date constructor with extra memes;
            /// </summary>
            public Date()
            {
            }
            public Date(Date copy)
            {
                year = copy.year;
                month = copy.year;
                day = copy.day;

            }
            public Date(int d, int m, int y)
            {
                year = y;
                month = m;
                day = d;
            }
            /// <summary>
            /// add meme
            /// </summary>
            public void Addyear()
            {
                year++;
            }
        }
        static void Main(string[] args)
        {
            birthday yeet = new birthday();
            Date yeetclass = new Date();
            //yeet.day = 6;
            yeetclass.year = 1997;
            yeetclass.Addyear();
            yeetclass.Addyear();
            yeetclass.Addyear();
            yeetclass.Addyear();
            Console.WriteLine("\n"+yeetclass.year);
            string input = Console.ReadLine(); //18-04-2016
            DateTime dateTime = DateTime.Parse(input);
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine(dateTime.DayOfWeek);
            Console.WriteLine(DateTime.ParseExact("19-06-2020", "dd-MM-yyyy", CultureInfo.GetCultureInfo("bg-BG"))    //one for the input culture, one for the output
                                                                    .ToString(CultureInfo.GetCultureInfo("bg-BG")));  //need to use globalisation name space REEEE

            
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
