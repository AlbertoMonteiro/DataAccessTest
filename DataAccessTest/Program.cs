using System;
using System.Collections.Generic;

namespace DataAccessTest
{
    partial class Program
    {
        private const int TOTAL_TIMES = 1;
        private const string CONNECTION_STRING = @"Server=(localdb)\mssqllocaldb;Database=DataAccessTest;Integrated security=true";

        static void Main(string[] args)
        {
            var results = new List<TestResult>();
            results.Add(AdoDataAccess(CONNECTION_STRING));
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);

            results.Add(DapperDataAccess(CONNECTION_STRING));
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);

            results.Add(EfDataAccess(CONNECTION_STRING));
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);

            results.Add(EfFastDataAccess(CONNECTION_STRING));
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);

            results.Add(NhDataAccess(CONNECTION_STRING));

            ConsoleTable.From(results).Write();

            Console.WriteLine("Teste finalizado");
        }
    }
}
