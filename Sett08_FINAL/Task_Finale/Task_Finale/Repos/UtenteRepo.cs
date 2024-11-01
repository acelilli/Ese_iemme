using Task_Finale.Models;

namespace Task_Finale.Repos
{
    public class UtenteRepo : IRepoLettura<Utente>, IRepoScrittura<Utente>
    {
        #region Context Injection + logger

        private Task_FinaleContext _context;
        private readonly ILogger<UtenteRepo> _logger;

        public UtenteRepo(Task_FinaleContext context, ILogger<UtenteRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        //private UtenteRepo() { }
        #endregion
        public bool Create(Utente entity)
        {
            bool risultato = false;
            try
            {
                _context.Utenti.Add(entity);
                _context.SaveChanges();
                risultato = true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Errore nella REPO");
                //Console.WriteLine(ex.Message);
                _logger.LogError(ex.Message);
            }
            return risultato;
        }

        public bool Delete(int id)
        {
            bool risultato = false;

            try
            {
                Utente ut = _context.Utenti.Single(d => d.UtenteID == id);
                _context.Utenti.Remove(ut);
                _context.SaveChanges();
                risultato = true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Errore nella REPO");
                //Console.WriteLine(ex.Message);
                _logger.LogError(ex.Message);
            }

            return risultato;
        }

        public IEnumerable<Utente> GetAll()
        {
            return _context.Utenti.ToList();
        }

        public Utente? GetByCodice(string cod)
        {
            return _context.Utenti.FirstOrDefault(u => u.CodiceUtente == cod);
        }

        public Utente? GetById(int id)
        {
            return _context.Utenti.FirstOrDefault(u => u.UtenteID == id);
        }

        /// <summary>
        /// Metodo che recupera un utente tramite la email e la password
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public Utente? GetByEmailPassword(string mail, string pass)
        {
            return _context.Utenti.FirstOrDefault(u => u.Email == mail && u.Password == pass);
        }

        /// <summary>
        /// Metodo che controlla se un certo utente è admin
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool CheckAdmin(Utente entity)
        {
            bool risultato = false;
            Utente? ute = _context.Utenti.FirstOrDefault(u => u.CodiceUtente == entity.CodiceUtente);
            if (ute is not null) 
            {
                if(ute.TipoUtente == "Admin")
                    risultato = true;
            }

            return risultato;
        }

        public bool Update(Utente entity)
        {
            bool risultato = false;
            Utente? ute = _context.Utenti.FirstOrDefault(u => u.CodiceUtente == entity.CodiceUtente);
            if (ute is null)
            {
                return risultato;
            }
            try
            {
                _context.Utenti.Update(entity);
                _context.SaveChanges();
                risultato = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return risultato;
        }
    }
}
