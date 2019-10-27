using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_IncreaseMinionAge
{
    class Program
    {
        static string connectionString = @"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            int[] minionIDs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            connection.Open();
            using (connection) 
            {
                command.CommandText = $"Update Minions " +
                    $"Set Age += 1, [Name] = UPPER(LEFT([Name], 1)) + LOWER(RIGHT([NAME], Len([Name])-1))" +
                    $"Where Id in ({string.Join(", ", minionIDs)})"; //Any Other way to get an array of parameters into a command?
                command.ExecuteNonQuery();
                command.CommandText = "Select [Name], Age From Minions";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) + ' ' + reader.GetInt32(1));
                }
            }
            Console.ReadKey();

        }
    }
}
