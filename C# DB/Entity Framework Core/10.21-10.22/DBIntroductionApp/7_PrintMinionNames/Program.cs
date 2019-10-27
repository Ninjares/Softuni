using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_PrintMinionNames
{
    class Program
    {
        static string connectionString = @"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT [Name] FROM Minions", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<string> minionNames = new List<string>();
            using (connection)
            {
                while (reader.Read())
                    minionNames.Add(reader.GetString(0));
            }
            bool right = false;
            while (minionNames.Count != 0)
            {
                if (right)
                {
                    Console.WriteLine(minionNames[minionNames.Count - 1]);
                    minionNames.RemoveAt(minionNames.Count - 1);
                    right = false;
                }
                else
                {
                    Console.WriteLine(minionNames[0]);
                    minionNames.RemoveAt(0);
                    right = true;
                }
            }
            Console.ReadKey();
        }
    }
}
