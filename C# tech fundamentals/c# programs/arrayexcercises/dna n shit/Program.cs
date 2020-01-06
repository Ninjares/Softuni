using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dna_n_shit
{
    class Program
    {
        static void Main(string[] args)
        {
            int dnalength = int.Parse(Console.ReadLine());
            string input="";
            int[] bestseq = new int[dnalength];         //dna seqeunce itself
            int bestsubs = -1;                          //the value of said best dna subsequence
            int hs = -1, sample = 0;                    //the index of the best subsequence - hs; ss- index of the gene in the while cycle
            int closestsubsindex = 999;                 //the inner index at which the subsequence of the best dna starts
            int higestsum = -1;
            while(input!="Clone them!")
            {
                sample++;                               //the index of our current gene
                 input = Console.ReadLine();
                if (input != "Clone them!")
                {
                    string[] dnaseqs = input.Split('!');
                   // foreach (string gen in dnaseqs) Console.Write(gen + " ");
                    int[] dnaseq = new int[dnalength];
                    for (int i = 0; i < dnalength; i++)
                        dnaseq[i] = int.Parse(dnaseqs[i]);

                    //subsequence calculation
                    int sum = 0;
                    foreach (int genome in dnaseq) sum += genome;
                    for (int i = 0; i < dnalength; i++)
                    {
                        int ss = 0;
                        
                        for (int j = i; j < dnalength && dnaseq[i] != 0 && dnaseq[j] != 0; j++)
                        {
                            ss++;
                        }
                        
                        if (ss > bestsubs || (ss == bestsubs && closestsubsindex > i)|| (ss == bestsubs && closestsubsindex == i && sum > higestsum))
                        {
                            hs = sample;
                            bestsubs = ss;
                            bestseq = dnaseq;
                            closestsubsindex = i;
                            higestsum = sum;
                        }
                    }
                }
            }

            Console.WriteLine("Best DNA sample {0} with sum: {1}.", hs, higestsum);
            foreach (int genome in bestseq) Console.Write(genome + " ");
            Console.ReadKey();
        }
    }
}
