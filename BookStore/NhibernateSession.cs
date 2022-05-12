using NHibernate;
using NHibernate.Cfg;
using ISession = NHibernate.ISession;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Reflection;
using BookStore.Models.Entities;
using BookStore.Models.Mappings;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Dialect;
using NHibernate.Driver;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using System.Data;

namespace BookStore
{
    public class NhibernateSession
    {
        /*
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            //configuration.Configure(@"D:\QLSVnew\QLSV\Models\hibernate.cfg.xml");
            //configuration.AddFile(@"D:\QLSVnew\QLSV\Mappings\Models.hbn.xml");
            //configuration.AddFile(@"D:\QLSVnew\QLSV\Mappings\DTO.hbn.xml");
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
        */
        /*
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory(); return _sessionFactory;
            }
        }
        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()			
         .Database(MsSqlConfiguration.MsSql2012.ConnectionString(
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BOOKSTORE;Integrated Security=True").ShowSql())
         .Mappings(m => m.FluentMappings
         .AddFromAssemblyOf<Program>())
         .ExposeConfiguration(cfg => new SchemaExport(cfg)
         //.Create(true, true)
         )
         .BuildSessionFactory();
        }
        */
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                  .ConnectionString("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BOOKSTORE;Integrated Security=True")
                  //.ShowSql()
                )
                .Mappings(m =>
                       m.FluentMappings
                       .AddFromAssemblyOf<Program>()
                       )
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                .Create(false, false))
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
            //return SessionFactory.OpenSession();
        }
        /*
        public static void CloseSession()
        {
            _sessionFactory.Close();
        }
        */
        //private const string CurrentSessionKey = "nhibernate.current_session";
        /*
        private static readonly ISessionFactory _sessionFactory;
        static NhibernateSession()
        {
            _sessionFactory = FluentConfigure();
        }


        public static ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
        public static void CloseSession()
        {
            _sessionFactory.Close();
        }
        public static void CloseSessionFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }

        public static ISessionFactory FluentConfigure()
        {
            return Fluently.Configure()
               //which database
               .Database(
                   MsSqlConfiguration.MsSql2012
                       .ConnectionString("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BOOKSTORE;Integrated Security=True")
                       )
               //find/set the mappings
               .Mappings(m => m.FluentMappings
                .AddFromAssemblyOf<Program>())
                .BuildSessionFactory();
        }
        */
    }
}
