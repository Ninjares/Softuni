using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] parse = input.Split();
            int[] sequence = new int[parse.Length];
            for (int i = 0; i < parse.Length; i++)
                sequence[i] = int.Parse(parse[i]);
            int largseq = 0, element=-99, seq=0;
            for(int i=0; i<sequence.Length; i++)
            {
                if (i == 0) { element = sequence[0]; seq++; }
                else if (sequence[i] == sequence[i - 1]) seq++;
                else seq = 1;
                if (largseq < seq) { largseq = seq; element = sequence[i]; }
            }
            for (int i = 0; i < largseq; i++) Console.Write(element + " ");
            Console.ReadKey(); 
        }
    }
}
