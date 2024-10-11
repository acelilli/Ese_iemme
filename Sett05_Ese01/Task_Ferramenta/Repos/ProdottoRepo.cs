using Task_Ferramenta.Models;

namespace Task_Ferramenta.Repos
{
    public class ProdottoRepo : IRepos<Prodotto>
    {
        private readonly FerramentaContext _context;
        public ProdottoRepo(FerramentaContext context)
        {
            _context = context;
        }
        public bool Create(Prodotto entity)
        {
            bool risultato = false;
            try
            {
                _context.Prodotto.Add(entity);
                _context.SaveChanges();
                risultato |= true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return risultato;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Prodotto? Get(int id)
        {
            return _context.Prodotto.Find(id);
        }

        public Prodotto? GetByCodice(string codice)
        {
            return _context.Prodotto.FirstOrDefault(p => p.CodiceBarre == codice);
        }

        public IEnumerable<Prodotto> GetAll()
        {
            return _context.Prodotto.ToList();
        }

        public bool Update(Prodotto entity)
        {
            throw new NotImplementedException();
        }
    }
}
