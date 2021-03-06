using NHibernate;
using BookStore.Interfaces;
using BookStore.Models.Entities;
using ISession = NHibernate.ISession;
using PagedList;
using System.Linq;

namespace BookStore.Data
{
    public class AuthorDAL : IData<Author>
    {
        public AuthorDAL()
        {
        }

        public Author Create(Author entity)
        {
            Author result = null;
            try
            {
                using (ISession session = NhibernateSession.OpenSession())
                {
                    using (var tx = session.BeginTransaction())
                    {
                        session.CreateSQLQuery("SET IDENTITY_INSERT dbo." + ConstParam.tblauthor + " ON").UniqueResult();
                        session.Save(entity);
                        tx.Commit();
                        session.CreateSQLQuery("SET IDENTITY_INSERT dbo." + ConstParam.tblauthor + " OFF").UniqueResult();
                        result = entity;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public bool Delete(Author entity)
        {
            bool result = false;
            try
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
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            return result;
        }

        public IPaged<Author> GetAll(string search, int pageNum, int pagedSize)
        {
            List<Author> list = new List<Author>();
            IPaged<Author> paged = null;
            try
            {
                if (!String.IsNullOrEmpty(search))
                {
                    using (ISession session = NhibernateSession.OpenSession())
                    {
                        list = (List<Author>)session.CreateCriteria<Author>().List<Author>()
                            .Where(x => x.AuthorName.ToLower().Contains(search)).ToList();
                    }
                }
                else
                {
                    using (ISession session = NhibernateSession.OpenSession())
                    {
                        list = (List<Author>)session.CreateCriteria<Author>().List<Author>();
                    }
                }
                paged = new IPaged<Author>();
                paged.PageNum = pageNum;
                paged.PageSize = pagedSize;
                paged.TotalCount = list.Count();
                paged.Result = list.ToPagedList(pageNum, pagedSize).ToList<Author>();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            return paged;
        }

        public Author GetById(int id)
        {
            Author entity = null;
            try
            {
                using (ISession session = NhibernateSession.OpenSession())
                {
                    if (IsExist(entity.AuthorId))
                        entity = session.Get<Author>(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return entity;
        }

        public Author Update(Author entity)
        {
            Author result = null;
            try
            {
                using (ISession session = NhibernateSession.OpenSession())
                {
                    if (IsExist(entity.AuthorId))
                    {
                        using (var tx = session.BeginTransaction())
                        {
                            session.Flush();
                            session.Merge(entity);
                            tx.Commit();
                            session.Flush();
                            result = entity;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                    result = session.Query<Author>().Any(x => x.AuthorId == id);
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
