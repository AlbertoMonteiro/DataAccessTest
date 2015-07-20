using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DataAccessTest
{
    partial class Program
    {
        public static void AdoDataAccess()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var customers = new List<Customer>();

            var stopwatch = Stopwatch.StartNew();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT [id],[first_name],[last_name],[email],[country] FROM [dbo].[Customer]", conn);
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

            Console.WriteLine("ADO Puro");
            Console.WriteLine("Objetos Gerados: {0}", customers.Count);
            Console.WriteLine("Tempo Total: {0}", stopwatch.Elapsed);

            customers = null;
        }

    }
}
