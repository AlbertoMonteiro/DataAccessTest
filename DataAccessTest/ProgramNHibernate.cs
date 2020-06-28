using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace DataAccessTest
{
    partial class Program
    {
        public static TestResult NhDataAccess(string connectionString)
        {
            var sessionFactory = CreateSessionFactory(connectionString);

            var customers = new List<Customer>();

            var stopwatch = Stopwatch.StartNew();
            using (var session = sessionFactory.OpenSession())
            {
                session.FlushMode = FlushMode.Manual;
                for (int i = 0; i < TOTAL_TIMES; i++)
                {
                    customers = session.Query<Customer>().ToList();
                }
            }
            stopwatch.Stop();
            customers = null;
            sessionFactory.Dispose();
            
            return new TestResult("NHibernate", stopwatch.Elapsed);
        }

        private static ISessionFactory CreateSessionFactory(string connectionString)
        {
            return Fluently.Configure()
                .Database(PostgreSQLConfiguration.Standard
                .ConnectionString(c => c.Is(connectionString)))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                .BuildSessionFactory();
        }
    }
}
