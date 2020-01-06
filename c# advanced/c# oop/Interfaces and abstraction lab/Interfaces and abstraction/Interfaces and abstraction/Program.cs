using System;

namespace Interfaces_and_abstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.Breathe();
            student.DrinccMilk();
            student.FacultyNumber = "000";

            IAnimal istudent = new Student();
            istudent.Breathe();
            //no milcc (mammals)
            //no faccultyNumber 

            

            
        }
    }
}
