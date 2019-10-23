using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Remove_Villain
{
    class Program
    {
        static string deleteQuery =  "Delete From MinionsVillains Where VillainId = {0} \n"+
                                     "Delete From Villains Where Id = {0}";
        static string connectionString = @"Server=.\SQLEXPRESS;" +
                                           "Database=MinionsDB;" +
                                           "Integrated Security=true;";
        static void Main(string[] args)
        {
            int Id = int.Parse(Console.ReadLine());
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.Transaction = transaction;
                command.CommandText = "Select [Name] From Villains Where Id = @villainID";
                
            }
            
        }
    }
}
