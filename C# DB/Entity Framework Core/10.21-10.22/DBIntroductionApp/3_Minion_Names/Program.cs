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
                    if (!villainReader.Read())
                        Console.WriteLine($"No villain with ID {id} exists in the database.");
                    else
                    {
                        Console.WriteLine($"Villain: {villainReader.GetString(0)}");
                        villainReader.Close();
                        try
                        {
                            SqlCommand minionsCommand = new SqlCommand(String.Format(MinionsQuery, id), connection);
                            SqlDataReader minionsReader = minionsCommand.ExecuteReader();
                            int row = 1;
                            while (minionsReader.Read())
                            {
                                Console.WriteLine($"{row++}. {minionsReader.GetString(0)} {minionsReader.GetInt32(1)}");
                            }
                            if (row == 1) Console.WriteLine("(no minions)");
                            minionsReader.Close();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadKey();

        }
    }
}
