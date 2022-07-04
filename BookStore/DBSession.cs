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
using NHibernate;

namespace BookStore
{
    public class DBSession
    {
        private readonly IConfiguration _appsetting;
        public DBSession(IConfiguration configuration)
        {
            _appsetting = configuration;
        }

        public ISession OpenSession()
        {
            var config = new Configuration();
            config.SessionFactoryName("Product");
            config.DataBaseIntegration(db =>
            {
                db.Dialect<MsSql2012Dialect>();
                db.Driver<SqlClientDriver>();
                db.ConnectionString = _appsetting.GetConnectionString("DefaultConnnection");
                db.Timeout = 10;
                db.LogSqlInConsole = true;
            });
            config.AddFile(@"Models\Mappings\Author.hbn.xml");
            config.AddFile(@"Models\Mappings\Book.hbn.xml");
            config.AddFile(@"Models\Mappings\Category.bhn.xml");
            config.AddFile(@"Models\Mappings\Evaluation.hbn.xml");
            config.AddFile(@"Models\Mappings\Picture.hbn.xml");
            config.AddFile(@"Models\Mappings\BaseModel.hbn.xml");
            ISessionFactory sessionFactory = config.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
