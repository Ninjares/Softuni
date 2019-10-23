using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Minion_Names
{
    class Program
    {
        static string connectionString = @" Server=.\SQLEXPRESS;" +
                                           "Database=MinionsDB;" +
                                           "Integrated Security=true;";
        static string VillainNameQuery = "Select [Name] From Villains Where Id = {0}";
        static string MinionsQuery = @" Select Minions.[Name], Minions.Age From Villains
                                        Inner Join MinionsVillains
                                        On Villains.Id = MinionsVillains.VillainId
                                        Inner Join Minions
                                        On Minions.Id = MinionsVillains.MinionId
                                        Where Villains.Id = {0}";
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {
                try
                {
                    SqlCommand commandVillain = new SqlCommand(String.Format(VillainNameQuery, id), connection);
                    SqlDataReader villainReader = commandVillain.ExecuteReader();
                    villainReader.Read();
                    Console.WriteLine($"Villain: {villainReader.GetString(0)}");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}
