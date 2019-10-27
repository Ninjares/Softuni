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
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.Transaction = transaction;
                command.CommandText = "Select [Name] From Villains Where Id = @villainId";
                command.Parameters.AddWithValue("@villainId", Id);
                object value = null;
                try 
                { 
                    value = command.ExecuteScalar();
                    if (value == null)
                    {
                        transaction.Rollback();
                        throw new ArgumentNullException(nameof(Id), "No such villain was found.");
                    }
                    else
                    {
                        string villaiName = (string)value;
                        command.CommandText = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";
                        int minionsDeleted = command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM Villains WHERE Id = @villainId";
                        transaction.Commit();
                        Console.WriteLine($"{villaiName} was deleted.\n{minionsDeleted} minions were released.");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
            
        }
    }
}
