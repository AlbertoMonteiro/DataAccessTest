using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DataAccessTest.EntityFramework;

namespace DataAccessTest
{
    partial class Program
    {
        public static void EfFastDataAccess()
        {
            List<Customer> customers = null;
            var db = new DataContext();
            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.EnsureTransactionsForFunctionsAndCommands = false;
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.UseDatabaseNullSemantics = false;
            db.Configuration.ValidateOnSaveEnabled = false;
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

            Console.WriteLine("Entity Framework Rápido");
            Console.WriteLine("Objetos Gerados: {0}", customers.Count);
            Console.WriteLine("Tempo Total: {0}", stopwatch.Elapsed);

            customers = null;
        }
    }
}
