using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DataAccessTest.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DataAccessTest
{
    partial class Program
    {
        public static TestResult EfFastDataAccess(string connectionString)
        {
            List<Customer> customers = null;
            var db = new DataContext(connectionString);
            db.ChangeTracker.AutoDetectChangesEnabled = false;
            db.ChangeTracker.LazyLoadingEnabled = false;
            db.Customers.FirstOrDefault();
            var stopwatch = Stopwatch.StartNew();
            using (db)
            {
                for (int i = 0; i < TOTAL_TIMES; i++)
                {
                    customers = db.Customers.AsNoTracking().ToList();
                }
            }
            stopwatch.Stop();
            db = null;

            customers = null;
            
            return new TestResult("Entity Framework Fast", stopwatch.Elapsed);
        }
    }
}
