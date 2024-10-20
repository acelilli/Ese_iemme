using API_VacanGio.Context;
using API_VacanGio.Models;
using Microsoft.EntityFrameworkCore;

namespace API_VacanGio.Repositories
{
    public class PacchettoRepo : IRepoLettura<Pacchetto>, IRepoScrittura<Pacchetto>
    {
        #region CONTEXT
        private readonly VaContext _context;
        //richiamo la repo di DestPacchetto per accedere ai metodi
        private readonly DestPacchettoRepo _dpRepository;

        public PacchettoRepo(VaContext context, DestPacchettoRepo dpRepo)
        {
            _context = context;
            _dpRepository = dpRepo;
        }

        #endregion
        public bool Create(Pacchetto entity)
        {
            //oltre all'entità pacchetto prendiamo la lista di ID da cercare nella tabella di appoggio
            bool risultato = false;
            try
            {
                _context.Pacchetti.Add(entity);
                _context.SaveChanges();
                risultato = true;
                //AggiungiDestinazioni(entity.PacchettoID);
                //Invece di fare la create dei record della tabella intermediaria qui
                // faccio una repo separata per Destinazioni_Pacchetto
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return risultato;
        }

        //private void AggiungiDestinazione(int pacID)
        //{
            
        //}

        public bool Delete(int id)
        {
            bool risultato = false;

            try
            {
                Pacchetto pac = _context.Pacchetti.Single(p => p.PacchettoID == id);
                _context.Pacchetti.Remove(pac);
                _context.SaveChanges();
                risultato = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return risultato;
        }

        public IEnumerable<Pacchetto> GetAll()
        {
            return _context.Pacchetti.Include(p => p.DesPac).ThenInclude(dp => dp.Dest).ToList();
        }

        public Pacchetto? GetById(int id)
        {
            return _context.Pacchetti.Find(id);
        }

        public Pacchetto? GetByCodice(string cod)
        {
                return _context.Pacchetti.Include(p => p.DesPac).ThenInclude(dp => dp.Dest).FirstOrDefault(p => p.CodicePac == cod);
        }

        public bool Update(Pacchetto entity)
        {
            bool risultato = false;
            Pacchetto? pac = _context.Pacchetti.FirstOrDefault(p => p.CodicePac == entity.CodicePac);
            if (pac is null)
            {
                return risultato;
            }
            try
            {
                _context.Pacchetti.Update(entity);
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
