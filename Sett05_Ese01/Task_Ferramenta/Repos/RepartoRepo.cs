using Task_Ferramenta.Models;

namespace Task_Ferramenta.Repos
{
    public class RepartoRepo : IRepos<Reparto>
    {
        private readonly FerramentaContext _context;
        public RepartoRepo(FerramentaContext context)
        {
            _context = context;
        }

        public bool Create(Reparto entity)
        {
            bool risultato = false;
            try
            {
                _context.Reparto.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

            return risultato;
        }

        public bool Delete(Reparto entity)
        {
            throw new NotImplementedException();
        }

        public Reparto? Get(int id)
        {
            return _context.Reparto.Find(id);
        }

        public Reparto? GetByCodice(string codice) 
        {
            return _context.Reparto.FirstOrDefault(r => r.RepartoCOD == codice);
        }

        public IEnumerable<Reparto> GetAll()
        {
            return _context.Reparto.ToList();
        }

        public bool Update(Reparto entity)
        {
            throw new NotImplementedException();
        }
    }
}
