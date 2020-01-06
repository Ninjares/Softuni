using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces_and_abstraction
{
    public interface IAnimal  //nqkkuv dogovor, maket za user koyto garantira che zad nego ima tva deto e v dogovor, nezavisimo kakvo ima zad dogovora
    {
        void Breathe();
    }
    public interface iMammal : IAnimal //V INTERFEICITE NQMA KOD IMA SAMO IMPLEMENTACII (parametri vse oshte sa nujni)
    {
        void DrinccMilk();
    }
    public abstract class Mammal { }
    class Person : iMammal
    {
        void IAnimal.Breathe() //this method can only be accessed through IAnimal
        {
            Console.WriteLine("Huh-hah");
        }

        public void DrinccMilk()
        {
            Console.WriteLine("Slurp slurp slurp");
        }
    }

}
