using System.Collections.Generic;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace DataAccessTest
{
    partial class Program
    {
        public static TestResult AdoDataAccess(string connectionString)
        {
            var customers = new List<Customer>();

            var stopwatch = Stopwatch.StartNew();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM customer", conn);
                for (int i = 0; i < TOTAL_TIMES; i++)
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            customers.Add(new Customer
                            {
                                Id = (int)dr[0],
                                FirstName = (string)dr[1],
                                LastName = (string)dr[2],
                                Email = (string)dr[3],
                                Country = (string)dr[4]
                            });
                        }
                    }
                }
                conn.Close();
            }
            stopwatch.Stop();

            customers = null;
            
            return new TestResult("ADO Puro", stopwatch.Elapsed);
        }

    }
}
