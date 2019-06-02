using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Word_Count
{
    class Program
    {

    static void Main(string[] args)
        {
            //loading text and words into a dictionary
            string texttocheck = File.ReadAllText(@"..\..\..\Text\text.txt");
            string[] wordstocheck = File.ReadAllText(@"..\..\..\Text\words.txt").Split(new string[] {"\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);
            var wordscontained = new Dictionary<string, int>();
            foreach (string word in wordstocheck) wordscontained.Add(word, 0);

            //creating a list of all the words in the text file
            string regex = @"[^a-zA-Z](?<word>[\w]+)";
            var Regex = new Regex(regex);
            var matches = Regex.Matches(texttocheck);
            List<string> allwords = new List<string>();
            foreach(Match match in matches)
            {
                allwords.Add(match.Groups["word"].Value);
            }

            //Counting and putting the results into a dictionary
            foreach(string word in wordstocheck)
            {
                var sb = new StringBuilder(word);
                sb[0] -= (char)32;
                string Ucase = sb.ToString();

                foreach(string sentword in allwords)
                {
                    if (word == sentword || Ucase == sentword) wordscontained[word]++;
                }
            }

            //writing the results in the file
            StringBuilder results = new StringBuilder();
            foreach (var pair in wordscontained.OrderByDescending(x=>x.Value)) results.AppendLine($"{pair.Key} - {pair.Value}");
            results.Remove(results.Length-2, 2);
            File.WriteAllText(@"..\..\..\Text\actualResult.txt", results.ToString());

            //comparing the contents of the actual vs expected results file
            if (File.ReadAllText(@"..\..\..\Text\actualResult.txt") == File.ReadAllText(@"..\..\..\Text\ExpectedResult.txt")) Console.WriteLine("Expected results confirmed!");
            else
            {
                //expected results
                string[] expres = File.ReadAllText(@"..\..\..\Text\ExpectedResult.txt").Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                var expected = new Dictionary<string, int>();
                foreach(string expword in expres)
                {
                    string[] pair = expword.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                    expected.Add(pair[0], int.Parse(pair[1]));
                }

                Console.WriteLine("Difference found in:");
                foreach (string word in wordstocheck)
                {
                    if (expected[word] > wordscontained[word]) Console.WriteLine($"{word} - {expected[word] - wordscontained[word]} less than expected");
                    if (expected[word] < wordscontained[word]) Console.WriteLine($"{word} - {wordscontained[word] - expected[word]} more than expected");
                }
               
            }
            Console.ReadKey();

        }
    }
}
