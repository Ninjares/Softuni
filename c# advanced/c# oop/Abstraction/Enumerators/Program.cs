using System;

namespace Enumerators
{
    class Program
    {
        enum DayOfBeek
        {
            Mon = 1, Tue, Wed, Thu, Fri = 10, Sat, Sun
        }
        enum MealSize
        {
            Small = 100,
            Medium = 150,
            Large = 220,
            XL = 300
        }

        
        static void Main(string[] args)
        {
            Console.WriteLine(DayOfBeek.Mon);
            Console.WriteLine((int)DayOfBeek.Sun);
            Console.WriteLine(MealSize.XL + "=" + (int)MealSize.XL);
            string day = "Mon";
            DayOfBeek parse = Enum.Parse<DayOfBeek>(day);
            Console.WriteLine(IsItMonday(parse));
        }

        static bool IsItMonday(DayOfBeek day)
        {
            if(DayOfBeek.Mon == day) return true;
            else return false;
        }
}
}
