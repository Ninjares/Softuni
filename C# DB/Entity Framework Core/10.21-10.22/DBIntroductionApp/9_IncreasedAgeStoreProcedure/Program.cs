using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_IncreasedAgeStoreProcedure
{
    class Program
    {
            //Create Or Alter Proc usp_GetOlder(@MinionId int) AS
            //Begin
            //    Update Minions Set Age+=1 Where Id = @MinionId
            //    Select[Name], Age From Minions Where Id = @MinionId
            //End

        static string connectionString = @"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("Exec usp_GetOlder @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            using (connection)
            {
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                Console.WriteLine($"{reader.GetString(0)} - {reader.GetInt32(1)} years old");
            }
            Console.ReadKey();
        }
    }
}
