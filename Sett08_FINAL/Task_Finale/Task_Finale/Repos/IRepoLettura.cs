namespace Task_Finale.Repos
{
    public interface IRepoLettura<T>
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        T? GetByCodice(string cod);

    }
}
