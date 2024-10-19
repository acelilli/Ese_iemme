using API_VacanGio.Context;
using API_VacanGio.Models;

namespace API_VacanGio.Repositories
{
    public class DestinazioneRepo : IRepoLettura<Destinazione>, IRepoScrittura<Destinazione>
    {
        private readonly VaContext _context;

        public DestinazioneRepo(VaContext context)
        {
            _context = context;
        }
        public bool Create(Destinazione entity)
        {
            bool risultato = false;
            try
            {
                _context.Destinazioni.Add(entity);
                _context.SaveChanges();
                risultato = true;
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
            return risultato;
        }

        public bool Delete(int id)
        {
            bool risultato = false;

            try 
            {
                Destinazione dest = _context.Destinazioni.Single(d => d.DestinazioneID == id);
                _context.Destinazioni.Remove(dest);
                _context.SaveChanges();
            }
            catch (Exception ex) { }

                return risultato;
        }

        public IEnumerable<Destinazione> GetAll()
        {
            return _context.Destinazioni.ToList();
        }

        public Destinazione? GetById(int id)
        {
            return _context.Destinazioni.Find(id);
        }

        public Destinazione? GetByCodice(string cod)
        {
            return _context.Destinazioni.FirstOrDefault(c => c.CodiceDes == cod);
        }

        public bool Update(Destinazione entity)
        {
            bool risultato = false;
            Destinazione? dest = _context.Destinazioni.FirstOrDefault(d => d.CodiceDes == entity.CodiceDes);
            if(dest is null)
            {
                return risultato;
            }
            try
            {
                _context.Destinazioni.Update(entity);
                _context.SaveChanges(); 
                risultato = true;
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }

            return risultato;
        }
    }
}
