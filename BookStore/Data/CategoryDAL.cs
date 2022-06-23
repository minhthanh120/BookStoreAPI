using NHibernate;
using BookStore.Interfaces;
using BookStore.Models.Entities;
using ISession = NHibernate.ISession;
using PagedList;
using BookStore.Models.Result;

namespace BookStore.Data
{
    public class CategoryDAL : IData<Category>
    {
        public CategoryDAL()
        {

        }
        public Category Create(Category entity)
        {
            Category result = new Category();
            try
            {
                using (ISession session = NhibernateSession.OpenSession())
                {
                    using (var tx = session.BeginTransaction())
                    {
                        session.CreateSQLQuery("SET IDENTITY_INSERT dbo." + ConstParam.tblcategory + " ON").UniqueResult();
                        session.Save(entity);
                        tx.Commit();
                        session.CreateSQLQuery("SET IDENTITY_INSERT dbo." + ConstParam.tblcategory + " OFF").UniqueResult();
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

        public bool Delete(Category entity)
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

        public IPaged<Category> GetAll(string search, int pageNum, int pageSize)
        {
            IPaged<Category> paged = null;
            try
            {
                List<Category> list = new List<Category>();
                if (!String.IsNullOrEmpty(search))
                {
                    using (ISession session = NhibernateSession.OpenSession())
                    {
                        list = (List<Category>)session.CreateCriteria<Category>().List<Category>()
                            .Where(x => x.CategoryName.ToLower().Contains(search)).ToList();
                    }
                }
                else
                {
                    using (ISession session = NhibernateSession.OpenSession())
                    {
                        list = (List<Category>)session.CreateCriteria<Category>().List<Category>();
                    }
                }
                paged = new IPaged<Category>();
                paged.PageSize = pageSize;
                paged.PageNum = pageNum;
                paged.TotalCount = list.Count();
                paged.Result = list.ToPagedList(pageNum, pageSize).ToList<Category>();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            return paged;
        }

        public Category GetById(int id)
        {
            Category obj = null;
            try
            {
                using (ISession session = NhibernateSession.OpenSession())
                {
                    if (!session.Query<Category>().Any(x => x.CategoryId == id))
                        return null;
                    obj = session.Get<Category>(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return obj;
        }

        public Category Update(Category entity)
        {
            Category obj = null;
            try
            {
                using (ISession session = NhibernateSession.OpenSession())
                {
                    if (session.Query<Category>().Any(x => x.CategoryId == entity.CategoryId))
                    {
                        using (var tx = session.BeginTransaction())
                        {
                            session.Flush();
                            session.Merge(entity);
                            tx.Commit();
                            session.Flush();
                            obj = entity;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            return obj;
        }
        public bool IsExist(int id)
        {
            bool result = false;
            try
            {
                using(ISession session = NhibernateSession.OpenSession())
                {
                    result  = session.Query<Category>().Any(x => x.CategoryId == id);
                }
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            return result;
        }
    }
}
