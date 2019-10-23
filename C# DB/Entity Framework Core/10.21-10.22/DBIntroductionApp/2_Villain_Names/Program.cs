using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Villain_Names
{
    class StartUp
    {
        static string connectionString = @"Server=.\SQLEXPRESS;" +
                                           "Database=MinionsDB;" +
                                           "Integrated Security=true;";

        static string Query = @"Select [Name], Count(*) as cnt From Villains
                                Inner Join MinionsVillains
                                On Villains.Id = MinionsVillains.VillainId
                                Group By[Name]
                                Having Count(*) > 3
                                Order By Count(*) DESC";
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {
                try
                {
                    SqlCommand getStuff = new SqlCommand(Query, connection);
                    SqlDataReader results = getStuff.ExecuteReader();
                    while (results.Read())
                    {
                        Console.WriteLine(results.GetString(0) + " - " + results.GetInt32(1));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
