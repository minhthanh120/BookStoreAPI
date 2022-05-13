namespace BookStore.Interfaces
{
    public interface IData<T>
    {
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
        List<T> GetAll();
        T GetById(int id);
    }
}
