namespace BookStore.Interfaces
{
    public interface IData<T>
    {
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
        IPaged<T> GetAll(string search, int pageNum, int pageSize);
        T GetById(int id);
        bool IsExist(int id);
    }
}
