namespace PadariaWeb.Repositories
{
    public interface IRepository<T,D>
    {
        Task<T> Save(T entity);
        Task<IEnumerable<T>> GetAll();
        T Update(T entity);
        Task Delete(D id);
        Task<T> GetById(D id);
    }
}
