using System;

namespace LectureNotes
{
    class Program
    {
        public static int GetNumber(string number)
        {
            
            try
            {
                if (number == "meem") throw new MyCustomException("meeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeem");
                return int.Parse(number);
                
            }
            catch (FormatException fex)//Catches this (fex)
            {
                throw new ArgumentException("This ain't a number, nigga", fex); //returns this (ArgumentExceottion)
            }
            catch (OverflowException oex)
            {
                throw new OverflowException("2 big", oex);
            }
            catch(MyCustomException ex)
            {
                throw ex;
            }
           
            
        }
        static void Main(string[] args)
        {
            Exception ex = new System.Exception("You dun fuccd up");
            //throw new System.Exception("Now you dun fuccd up");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine(ex.InnerException);
            //try-catch-finally
            try
            {
                //do some work that can shit the bed
            }
            catch(ArgumentException someexception)
            {
                //do shit some shit here if an exception arises
            }
            catch(OverflowException someotherexception)
            {
                //Exception catches everything and all other exceptions become unreachable
            }

            try
            {
                int a = GetNumber(Console.ReadLine());
            }
            catch(FormatException fex)
            {
                throw;
            }
            catch(OverflowException oex)
            {
                //throw;
            }
            catch(Exception realshit)
            {
                throw realshit;
            }
            finally // Vinagi se izpulnqva osven ako nqma throw v catch
            {
                Console.WriteLine("we be done");
            }

            //Nqma po-trash praktrika ot prazen catch
            

            

            
        }
    }
}
