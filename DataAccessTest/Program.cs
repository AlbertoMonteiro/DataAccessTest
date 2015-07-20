using System;
using System.Collections.Generic;
using NHibernate.Mapping;

namespace DataAccessTest
{
    partial class Program
    {
        private const int TOTAL_TIMES = 1;

        static void Main(string[] args)
        {
            var results = new List<TestResult>();
            results.Add(AdoDataAccess());
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);

            results.Add(DapperDataAccess());
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);

            results.Add(EfDataAccess());
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);

            results.Add(EfFastDataAccess());
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);

            results.Add(NhDataAccess());

            ConsoleTable.From(results).Write();

            Console.WriteLine("Teste finalizado");
            Console.ReadKey();
        }
    }
}
