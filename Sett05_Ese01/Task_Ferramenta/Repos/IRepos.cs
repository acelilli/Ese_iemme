namespace Task_Ferramenta.Repos
{
    public interface IRepos<T>
    {
        IEnumerable<T> GetAll();
        T? Get(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
