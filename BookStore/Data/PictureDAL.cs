using NHibernate;
using BookStore.Interfaces;
using BookStore.Models.Entities;
using ISession = NHibernate.ISession;
namespace BookStore.Data
{
    public class PictureDAL : IData<Picture>
    {
        private readonly IData<Book> _dbBook;
        public PictureDAL(IData<Book> dbBook)
        {
            _dbBook = dbBook;
        }

        public Picture Create(Picture entity)
        {
            Picture result = null;
            try
            {
                using (ISession session = NhibernateSession.OpenSession())
                {
                    if (IsExist(entity.Book.BookId))
                    {
                        using (var tx = session.BeginTransaction())
                        {
                            session.Flush();
                            session.Save(entity);
                            tx.Commit();
                            session.Flush();
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

        public Picture Update(Picture entity)
        {
            Picture result = null;
            try
            {
                using (ISession session = NhibernateSession.OpenSession())
                {
                    if (IsExist(entity.PictureId))
                    {
                        using(var tx = session.BeginTransaction())
                        {
                            session.Flush();
                            session.Update(entity);
                            tx.Commit();
                            session.Flush();
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

        public bool Delete(Picture entity)
        {
            bool result = false;
            try
            {
                using (ISession session = NhibernateSession.OpenSession())
                {
                    if (IsExist(entity.PictureId))
                    {
                        using (var tx = session.BeginTransaction())
                        {
                            session.Flush();
                            session.Delete(entity.PictureId);
                            tx.Commit();
                            session.Flush();
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

        public IPaged<Picture> GetAll(string search, int pageNum, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Picture GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(int id)
        {
            bool result = false;
            try
            {
                using (ISession session = NhibernateSession.OpenSession())
                {
                    result = session.Query<Picture>().Any(x => x.PictureId == id);
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
