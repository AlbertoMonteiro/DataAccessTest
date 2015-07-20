using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DataAccessTest.EntityFramework;

namespace DataAccessTest
{
    partial class Program
    {
        public static void EfDataAccess()
        {
            List<Customer> customers = null;
            var db = new DataContext();
            var stopwatch = Stopwatch.StartNew();
            using (db)
            {
                for (int i = 0; i < TOTAL_TIMES; i++)
                {
                    customers = db.Customers.ToList();
                }
            }
            stopwatch.Stop();
            db = null;

            Console.WriteLine("Entity Framework");
            Console.WriteLine("Objetos Gerados: {0}", customers.Count);
            Console.WriteLine("Tempo Total: {0}", stopwatch.Elapsed);

            customers = null;
        }
    }
}
