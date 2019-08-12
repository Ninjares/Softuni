using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] c = input.Split(';');
                try
                {
                    switch (c[0])
                    {

                        case "Team":
                            {
                                if (!teams.ContainsKey(c[1])) teams.Add(c[1], new Team(c[1]));
                                break;
                            }
                        case "Add":
                            {
                                if (!teams.ContainsKey(c[1])) throw new Exception($"Team {c[1]} does not exist.");
                                else teams[c[1]].AddPlayer(new Player(c[2], int.Parse(c[3]), int.Parse(c[4]), int.Parse(c[5]), int.Parse(c[6]), int.Parse(c[7])));
                                break;
                            }
                        case "Remove":
                            {
                                if (!teams.ContainsKey(c[1])) throw new Exception($"Team {c[1]} does not exist.");
                                else teams[c[1]].RemovePlayer(c[2]);
                                break;
                            }
                        case "Rating":
                            {
                                if (!teams.ContainsKey(c[1])) throw new Exception($"Team {c[1]} does not exist.");
                                else Console.WriteLine($"{teams[c[1]].Name} - {teams[c[1]].Rating}");
                                break;
                            }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                input = Console.ReadLine();
            }
        }
    }
}
