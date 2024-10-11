namespace Task_Ferramenta.Services
{
    public interface IServices<T>
    {
        IEnumerable<T> Lista();
        //perca per codice
        T? Cerca(string varCod);
    }
}
