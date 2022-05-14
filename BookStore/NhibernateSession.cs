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
        public NhibernateSession()
        {

        }
        //private static ISessionFactory _sessionFactory;


        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            configuration.Configure(@"C:\Users\MinhThanh\source\repos\BookStore\BookStore\Models\hibernate.cfg.xml");
            configuration.AddFile(@"C:\Users\MinhThanh\source\repos\BookStore\BookStore\Models\Mappings\Author.hbn.xml");
            configuration.AddFile(@"C:\Users\MinhThanh\source\repos\BookStore\BookStore\Models\Mappings\Book.hbn.xml");
            configuration.AddFile(@"C:\Users\MinhThanh\source\repos\BookStore\BookStore\Models\Mappings\Category.bhn.xml");
            configuration.AddFile(@"C:\Users\MinhThanh\source\repos\BookStore\BookStore\Models\Mappings\Evaluation.hbn.xml");
            configuration.AddFile(@"C:\Users\MinhThanh\source\repos\BookStore\BookStore\Models\Mappings\Picture.hbn.xml");
            configuration.AddFile(@"C:\Users\MinhThanh\source\repos\BookStore\BookStore\Models\Mappings\BaseModel.hbn.xml");
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
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
