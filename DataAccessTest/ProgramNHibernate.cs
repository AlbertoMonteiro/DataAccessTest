﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Linq;

namespace DataAccessTest
{
    partial class Program
    {
        public static void NhDataAccess()
        {
            var sessionFactory = CreateSessionFactory();

            var customers = new List<Customer>();

            var stopwatch = Stopwatch.StartNew();
            using (var session = sessionFactory.OpenSession())
            {
                for (int i = 0; i < TOTAL_TIMES; i++)
                {
                    customers = session.Query<Customer>().ToList();

                }
            }
            stopwatch.Stop();

            Console.WriteLine("NHibernate");
            Console.WriteLine("Objetos Gerados: {0}", customers.Count);
            Console.WriteLine("Tempo Total: {0}", stopwatch.Elapsed);

            customers = null;
            sessionFactory.Dispose();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                .ConnectionString(c => c.FromConnectionStringWithKey("ConnectionString")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                .BuildSessionFactory();
        }
    }
}