using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using Dapper;
using Npgsql;

namespace DataAccessTest
{
    partial class Program
    {
        public static TestResult DapperDataAccess(string connectionString)
        {
            IEnumerable<Customer> customers = new List<Customer>();

            var stopwatch = Stopwatch.StartNew();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                for (int i = 0; i < TOTAL_TIMES; i++)
                {
                    customers = conn.Query<Customer>("SELECT id, first_name, last_name, email, country FROM public.\"Customer\"");
                }
                conn.Close();
            }
            stopwatch.Stop();

            customers = null;
            
            return new TestResult("Dapper", stopwatch.Elapsed);
        }
    }
}
