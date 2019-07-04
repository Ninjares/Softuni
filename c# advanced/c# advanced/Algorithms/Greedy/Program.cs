using System;
using System.Collections.Generic;
using System.Linq;

namespace Greedy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToArray();
            int sum = int.Parse(Console.ReadLine());
            Dictionary<int, int> coinUses = new Dictionary<int, int>();
            foreach(int coin in coins)
            {
                coinUses.Add(coin, 0);
            }
            int atcoin = 0;
            while (sum != 0)
            {
                while (sum >= coins[atcoin])
                {
                    coinUses[coins[atcoin]]++;
                    sum -= coins[atcoin];
                }
                atcoin++;
                if (atcoin == coins.Length&&sum!=0){ Console.WriteLine("shit"); break;}
            }
            if(sum==0)
            foreach (var item in coinUses) Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}
