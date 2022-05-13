using NHibernate;
using BookStore.Interfaces;
using BookStore.Models.Entities;
using ISession = NHibernate.ISession;

namespace BookStore.Data
{
    public class AuthorDAL:IData<Author>
    {
        public AuthorDAL()
        {

        }

        public Author Create(Author entity)
        {
            Author author = new Author();
            using (ISession session = NhibernateSession.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.CreateSQLQuery("SET IDENTITY_INSERT dbo.Author ON").UniqueResult();
                    session.Save(entity);
                    tx.Commit();
                    session.CreateSQLQuery("SET IDENTITY_INSERT dbo.Author OFF").UniqueResult();
                    author = entity;
                }
            }
            return author;
        }

        public bool Delete(Author entity)
        {
            Author author = new Author();
            using (ISession session = NhibernateSession.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Delete(entity);
                    tx.Commit();
                    author = entity;
                }
            }
            return true;
        }

        public List<Author> GetAll()
        {
            List<Author> list = new List<Author>();
            using (ISession session = NhibernateSession.OpenSession())
            {
                ;// Open a session to conect to the database
                list = (List<Author>)session.CreateCriteria<Author>().SetFetchMode("Books", FetchMode.Lazy).List<Author>();
            }
            // Open a session to conect to the database
            return list;
        }

        public Author GetById(int id)
        {
            Author entity = new Author();
            using(ISession session = NhibernateSession.OpenSession())
            {
                entity = session.Get<Author>(id);
            }
            return entity;
        }

        public Author Update(Author entity)
        {
            Author author = new Author();
            using (ISession session = NhibernateSession.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Update(entity);
                    tx.Commit();
                    author = entity;
                }
            }
            return author;
        }
    }
}
