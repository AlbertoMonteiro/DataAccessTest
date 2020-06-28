using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DataAccessTest.EntityFramework;

namespace DataAccessTest
{
    partial class Program
    {
        public static TestResult EfDataAccess(string connectionString)
        {
            List<Customer> customers = null;
            var db = new DataContext(connectionString);
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
            customers = null;

            return new TestResult("Entity Framework", stopwatch.Elapsed);
        }
    }
}
