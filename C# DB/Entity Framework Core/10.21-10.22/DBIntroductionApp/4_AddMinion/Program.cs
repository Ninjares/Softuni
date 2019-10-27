using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_AddMinion
{
    class Program
    {
        static string connectionString = @" Server=.\SQLEXPRESS;" +
                                           "Database=MinionsDB;" +
                                           "Integrated Security=true;";
        static void Main(string[] args)
        {
            string[] minionData = Console.ReadLine().Split();
            string[] villainData = Console.ReadLine().Split();
            SqlCommand command = new SqlCommand();
            command.Connection = new SqlConnection(connectionString);
            command.Connection.Open();
            command.Transaction = command.Connection.BeginTransaction();
            try
            {
                int villainId, minionId, TownId;

                command.CommandText = $"SELECT Id FROM Towns WHERE Name = '{minionData[3]}'";
                if (command.ExecuteScalar() == null)
                {
                    command.CommandText = $"INSERT INTO Towns(Name) VALUES('{minionData[3]}')";
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Town {minionData[3]} added to the database");
                    command.CommandText = $"SELECT Id FROM Towns WHERE Name = '{minionData[3]}'";
                }
                TownId = (int)command.ExecuteScalar();
            

                command.CommandText = $"SELECT Id FROM Villains WHERE Name = '{villainData[1]}'";
                if (command.ExecuteScalar() == null) 
                { 
                    command.CommandText = $"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES ('{villainData[1]}', 4)";
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Villain {villainData[1]} added to the database");
                    command.CommandText = $"SELECT Id FROM Villains WHERE Name = '{villainData[1]}'";
                }
                villainId = (int)command.ExecuteScalar();

                command.CommandText = $"SELECT Id FROM Minions WHERE Name = '{minionData[1]}'";
                if(command.ExecuteScalar() == null)
                {
                    command.CommandText = $"INSERT INTO Minions(Name, Age, TownId) VALUES('{minionData[1]}', {int.Parse(minionData[2])}, {TownId})";
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Minion {minionData[1]} added to the database");
                    command.CommandText = $"SELECT Id FROM Minions WHERE Name = '{minionData[1]}'";
                }
                minionId = (int)command.ExecuteScalar();

                command.CommandText = $"INSERT INTO MinionsVillains(MinionId, VillainId) VALUES({minionId}, {villainId})";
                command.ExecuteNonQuery();
                Console.WriteLine($"Successfully added {minionData[1]} to be minion of {villainData[1]}.");
                command.Transaction.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            command.Connection.Close();
            Console.ReadKey();
        }
    }
}
