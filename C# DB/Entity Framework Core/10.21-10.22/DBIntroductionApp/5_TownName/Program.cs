using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_TownName
{
    class Program
    {
        static string connectionString = @"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"Select Id From Countries Where [Name] = '{countryName}'";
                int countryCode = -1;
                try
                {
                    countryCode = (int)command.ExecuteScalar();
                }
                catch(Exception)
                {
                    Console.WriteLine("Country not found");
                    Environment.Exit(0);
                }
                command.CommandText = $"UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = {countryCode}";
                int townsAffected = command.ExecuteNonQuery();
                if (townsAffected == 0)
                    Console.WriteLine($"No town names were affected.");
                else
                {
                    Console.WriteLine($"{townsAffected} town names were affected.");
                    command.CommandText = $"Select Name From Towns WHERE CountryCode = {countryCode}";
                    List<string> towns = new List<string>();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        towns.Add(dataReader.GetString(0));
                    }
                    Console.WriteLine($"[{string.Join(", ",towns)}]");
                }
            }
            Console.ReadKey();
        }
    }
}
