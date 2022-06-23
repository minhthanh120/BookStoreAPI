using BookStore.Interfaces;
using BookStore.Models.Entities;
using PagedList;
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
            Book temp = null;
            try
            {
                using (ISession session = NhibernateSession.OpenSession())
                {
                    using (var tx = session.BeginTransaction())
                    {
                        session.CreateSQLQuery("SET IDENTITY_INSERT dbo." + ConstParam.tblbook + " ON").UniqueResult();
                        session.Save(entity);
                        tx.Commit();
                        session.CreateSQLQuery("SET IDENTITY_INSERT dbo." + ConstParam.tblbook + " OFF").UniqueResult();
                        temp = entity;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            return temp;
        }

        public bool Delete(Book entity)
        {
            bool result = false;
            try
            {
                if (IsExist(entity.BookId))
                {
                    using (ISession session = NhibernateSession.OpenSession())
                    {
                        using (var tx = session.BeginTransaction())
                        {
                            session.Delete(entity);
                            tx.Commit();
                            result = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            return result;
        }
        public IPaged<Book> GetAll(string search, int pageNum, int pagedSize)
        {

            IPaged<Book> paged = null;
            try
            {
                List<Book> list = new List<Book>();
                if (!String.IsNullOrEmpty(search))
                {
                    using (ISession session = NhibernateSession.OpenSession())
                    {
                        list = (List<Book>)session.CreateCriteria<Book>().List<Book>()
                            .Where(x => x.BookName.ToLower().Contains(search)).ToList();
                    }
                }
                else
                {
                    using (ISession session = NhibernateSession.OpenSession())
                    {
                        list = (List<Book>)session.CreateCriteria<Book>().List<Book>();
                    }
                }
                paged = new IPaged<Book>();
                paged.PageNum = pageNum;
                paged.PageSize = pagedSize;
                paged.TotalCount = list.Count();
                paged.Result = list.ToPagedList(pageNum, pagedSize).ToList<Book>();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            // Open a session to conect to the database

            return paged;
        }

        public Book GetById(int id)
        {
            Book result = null;
            try
            {
                if (IsExist(id))
                {
                    using (ISession session = NhibernateSession.OpenSession())
                    {
                        result = session.Get<Book>(id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            return result;
        }

        public Book Update(Book entity)
        {
            Book result = null;
            try
            {
                if (IsExist(entity.BookId))
                {
                    using (ISession session = NhibernateSession.OpenSession())
                    {
                        using (var tx = session.BeginTransaction())
                        {
                            session.Update(entity);
                            tx.Commit();
                            result = entity;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            return result;
        }

        public bool IsExist(int id)
        {
            bool result = false;
            try
            {
                using (ISession session = NhibernateSession.OpenSession())
                {
                    result = session.Query<Book>().Any(x => x.BookId == id);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            return result;
        }
    }
}
