using NHibernate;
using BookStore.Interfaces;
using BookStore.Models.Entities;
using ISession = NHibernate.ISession;
namespace BookStore.Data
{
    public class BookDAL : IData<Book>
    {
        public BookDAL()
        {

        }
        public Book Create(Book entity)
        {
            Book temp = new Book();
            using (ISession session = NhibernateSession.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.CreateSQLQuery("SET IDENTITY_INSERT dbo.Book ON").UniqueResult();
                    session.Save(entity);
                    tx.Commit();
                    session.CreateSQLQuery("SET IDENTITY_INSERT dbo.Book OFF").UniqueResult();
                    temp = entity;
                }
            }
            return temp;
        }

        public bool Delete(Book entity)
        {
            using (ISession session = NhibernateSession.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Delete(entity);
                    tx.Commit();
                }
            }
            return true;
        }
        public List<Book> GetAll()
        {
            List<Book> list = new List<Book>();
            using (ISession session = NhibernateSession.OpenSession())
            {
                ;// Open a session to conect to the database
                list = (List<Book>)session.CreateCriteria<Book>().List<Book>();
            }
            // Open a session to conect to the database
            return list;
        }

        public Book GetById(int id)
        {
            Book entity = new Book();
            using (ISession session = NhibernateSession.OpenSession())
            {
                entity = session.Get<Book>(id);
            }
            return entity;
        }

        public Book Update(Book entity)
        {
            Book temp = new Book();
            using (ISession session = NhibernateSession.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Update(entity);
                    tx.Commit();
                    temp = entity;
                }
            }
            return temp;
        }
    }
}
