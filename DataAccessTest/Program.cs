using System;

namespace DataAccessTest
{
    partial class Program
    {
        private const int TOTAL_TIMES = 1;

        static void Main(string[] args)
        {
            //AdoDataAccess();
            //Console.WriteLine();
            //GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);

            //DapperDataAccess();
            //Console.WriteLine();
            //GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
/*
            EfDataAccess();
            Console.WriteLine();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);*/

            EfFastDataAccess();
            Console.WriteLine();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);

            //NhDataAccess();

            Console.WriteLine("Teste finalizado");
            Console.ReadKey();
        }
    }
}
