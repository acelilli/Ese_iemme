using API_VacanGio.Context;
using API_VacanGio.Models;

namespace API_VacanGio.Repositories
{
    public class DestPacchettoRepo : IRepoLettura<DestinazionePacchetto>, IRepoScrittura<DestinazionePacchetto>
    {
        #region CONTEXT
        private readonly VaContext _context;

        public DestPacchettoRepo(VaContext context)
        {
            _context = context;
        }
        #endregion
        public bool Create(DestinazionePacchetto entity)
        {
            bool risultato = false;
            if(AggiungiAlPacchetto(entity.PacchettoRIF, entity.DestinazioneRIF))
            {
                try
                            {
                                AggiungiAlPacchetto(entity.PacchettoRIF, entity.DestinazioneRIF);
                                _context.DestPacchettos.Add(entity);
                                _context.SaveChanges();
                                risultato = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
            }
            
            return risultato;
        }

        public bool AggiungiAlPacchetto(int pacchettoId, int destinazioneID) 
        {
            bool risultato = false;
            var pac = _context.Pacchetti.Find(pacchettoId);
            var des = _context.Destinazioni.Find(destinazioneID);
            //var des = _destRepo.GetById(destinazioneID);

            if (pac is not null)
            {
                Console.WriteLine("Pacchetto trovato");
                risultato = true;
                return risultato;
            } else
                Console.WriteLine("Pacchetto non trovato");
            

            if (des is not null)
            {
                Console.WriteLine("Destinazione trovata");
                risultato = true;
                return risultato;
            }
            else
                Console.WriteLine("Destinazione non trovata");
            


            return risultato;
        }

        public bool Delete(int id)
        {
            bool risultato = false;

            try
            {
                DestinazionePacchetto dePa = _context.DestPacchettos.Single(dp => dp.Destinazione_PacchettoID == id);
                _context.DestPacchettos.Remove(dePa);
                _context.SaveChanges();
                risultato = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return risultato;
        }

        public IEnumerable<DestinazionePacchetto> GetAll()
        {
            throw new NotImplementedException();
        }

        public DestinazionePacchetto? GetById(int id)
        {
            return _context.DestPacchettos.Find(id);
        }

        public bool Update(DestinazionePacchetto entity)
        {
            bool risultato = false;
            DestinazionePacchetto? desPac = _context.DestPacchettos.FirstOrDefault(dp => dp.Destinazione_PacchettoID == entity.Destinazione_PacchettoID);
            if (desPac is null)
            {
                return risultato;
            }
            try
            {
                _context.DestPacchettos.Update(entity);
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
