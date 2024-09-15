namespace PadariaWeb.Repositories
{
    public interface IRepository<T,D>
    {
        T Save(T entity);
        IEnumerable<T> GetAll();
        T Update(T entity);
        void Delete(D id);
        T GetById(D id);
    }
}
