using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Dapper;

namespace DataAccessTest
{
    partial class Program
    {
        public static void DapperDataAccess()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            IEnumerable<Customer> customers = new List<Customer>();

            var stopwatch = Stopwatch.StartNew();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                for (int i = 0; i < TOTAL_TIMES; i++)
                {
                    customers = conn.Query<Customer>("SELECT [id] as Id,[first_name] as FirstName, [last_name] as LastName, [email] as Email, [country] as Country FROM [dbo].[Customer]");
                }
                conn.Close();
            }
            stopwatch.Stop();

            Console.WriteLine("Dapper");
            Console.WriteLine("Objetos Gerados: {0}", customers.ToList().Count);
            Console.WriteLine("Tempo Total: {0}", stopwatch.Elapsed);

            customers = null;
        }
    }
}
