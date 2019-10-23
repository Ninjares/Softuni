using System;
using System.Data.SqlClient;

namespace AdoNetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=Softuni;Integrated Security=true");
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("Select * From Employees", connection);
                Console.WriteLine(command.ExecuteNonQuery());
            }
        }
    }
}
