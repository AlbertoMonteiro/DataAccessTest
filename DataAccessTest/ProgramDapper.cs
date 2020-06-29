using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using Dapper;
using MySql.Data.MySqlClient;

namespace DataAccessTest
{
    partial class Program
    {
        public static TestResult DapperDataAccess(string connectionString)
        {
            IEnumerable<Customer> customers = new List<Customer>();

            var stopwatch = Stopwatch.StartNew();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                for (int i = 0; i < TOTAL_TIMES; i++)
                {
                    customers = conn.Query<Customer>("SELECT id as Id,first_name as FirstName, last_name as LastName, email as Email, country as Country FROM customer");
                }
                conn.Close();
            }
            stopwatch.Stop();

            customers = null;
            
            return new TestResult("Dapper", stopwatch.Elapsed);
        }
    }
}
