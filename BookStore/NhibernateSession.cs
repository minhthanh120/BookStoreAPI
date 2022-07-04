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
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using Microsoft.Extensions.Configuration;
using BookStore.Models;

namespace BookStore
{
    public class NhibernateSession
    {
        public NhibernateSession()
        {

        }
        public static ISessionFactory _sessionFactory;
        public static Configuration _configuration1;
        public static Configuration _appstart;

        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            configuration.Configure(@"Models\hibernate.cfg.xml");
            //configuration.SessionFactoryName("Product");
            //configuration.DataBaseIntegration(db =>
            //{
            //    db.Dialect<MsSql2012Dialect>();
            //    db.Driver<SqlClientDriver>();
            //    db.ConnectionString = 
            //})
            configuration.AddFile(@"Models\Mappings\Author.hbn.xml");
            configuration.AddFile(@"Models\Mappings\Book.hbn.xml");
            configuration.AddFile(@"Models\Mappings\Category.bhn.xml");
            configuration.AddFile(@"Models\Mappings\Evaluation.hbn.xml");
            configuration.AddFile(@"Models\Mappings\Picture.hbn.xml");
            configuration.AddFile(@"Models\Mappings\BaseModel.hbn.xml");
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
        public static ISession UserSession()
        {
            _configuration1 = Configuration();
            HbmMapping mapping = GetMapping();
            _configuration1.AddDeserializedMapping(mapping, "NHSchemaTest");
            SchemaMetadataUpdater.QuoteTableAndColumns(_configuration1);
            _sessionFactory= _configuration1.BuildSessionFactory();
            return _sessionFactory.OpenSession();
        }

        public static Configuration Configuration()
        {
            Configuration config = new Configuration();
            config.SessionFactoryName("BuildIt");
            config.DataBaseIntegration(db =>
            {
                db.Dialect<MsSql2012Dialect>();
                db.Driver<SqlClientDriver>();
                db.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=UserAuthentication;Integrated Security=True";
                db.Timeout = 10;
            });
            return config;
        }
        protected static HbmMapping GetMapping()
        {
            ModelMapper mapper = new ModelMapper();
            mapper.AddMapping<UserMapping>();
            mapper.AddMapping<UserPasswordMapping>();
            HbmMapping mapping = mapper.CompileMappingFor(new[] { typeof(User), typeof(UserPassword) });
            return mapping;
        }

        /*
        public static ISession OpenSession()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                  .ConnectionString("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BOOKSTORE;Integrated Security=True")
                //.ShowSql()
                )
                .Mappings(m =>
                       m.FluentMappings
                       .AddFromAssemblyOf<BookMap>()
                       .AddFromAssemblyOf<AuthorMap>()
                       .AddFromAssemblyOf<PictureMap>()
                       .AddFromAssemblyOf<EvaluationMap>()
                       .AddFromAssemblyOf<CategoryMap>()
                       )
                //.ExposeConfiguration(cfg => new SchemaExport(cfg)
                //.Create(false, false))
                .BuildSessionFactory();

            return _sessionFactory.OpenSession();
        }
        */
        //public static void CloseSessionFactory()
        //{
        //    _sessionFactory.Close();
        //}

    }
}
