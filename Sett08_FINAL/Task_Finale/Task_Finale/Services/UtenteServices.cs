using Task_Finale.Models;
using Task_Finale.Repos;

namespace Task_Finale.Services
{
    public class UtenteServices : IServices<UtenteDTO>
    {
        #region Repo Injection + logger
        private UtenteRepo _repo;
        private readonly ILogger<UtenteServices> _logger;

        public UtenteServices(UtenteRepo repo, ILogger<UtenteServices> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        #endregion
        public bool Aggiorna(UtenteDTO entity)
        {
            bool risultato = false;

            if (entity is not null && !string.IsNullOrWhiteSpace(entity.CodUt))
            {
                var ute = _repo.GetByCodice(entity.CodUt);
                //Destinazione? des = _repository.GetByCodice(entity.CodDes);
                if (ute != null && entity.UsNa is not null && entity.Mail is not null && entity.Pass is not null)
                {
                    ute.CodiceUtente = entity.CodUt is not null ? entity.CodUt : ute.CodiceUtente;
                    ute.Username = entity.UsNa is not null ? entity.UsNa : ute.Username;
                    ute.Email = entity.Mail is not null ? entity.Mail : ute.Email;
                    ute.Password = entity.Pass is not null ? entity.Pass : ute.Password;
                    ute.TipoUtente = entity.TipoUt is not null ? entity.TipoUt : ute.TipoUtente;

                    risultato = _repo.Update(ute);
                }
            } else 
            {
                _logger.LogError("I campi obbligatori erano vuoti");
            }

            return risultato;
        }

        public UtenteDTO? CercaPerCodice(string codice)
        {
            UtenteDTO? mioUtente = null;

            Utente? utente = _repo.GetByCodice(codice);
            if (mioUtente is not null)
            {
                mioUtente = new UtenteDTO()
                {
                    CodUt = utente.CodiceUtente,
                    UsNa = utente.Username,
                    Pass = utente.Password,
                    Mail = utente.Email,
                    TipoUt = utente.TipoUtente,
                };
            }
            else
            {
                _logger.LogError("Utente non trovato");
            }

            return mioUtente;
        }

        public UtenteDTO? CercaPerMailPassword(string email, string pass)
        {
            UtenteDTO? mioUtente = null;

            Utente? utente = _repo.GetByEmailPassword(email, pass);
            if (mioUtente is not null)
            {
                mioUtente = new UtenteDTO()
                {
                    CodUt = utente.CodiceUtente,
                    UsNa = utente.Username,
                    Pass = utente.Password,
                    Mail = utente.Email,
                    TipoUt = utente.TipoUtente,
                };
            }
            else
            {
                _logger.LogError("Utente non trovato");
            }

            return mioUtente;
        }

        public IEnumerable<UtenteDTO> CercaTutti()
        {
            ICollection<UtenteDTO> risultato = new List<UtenteDTO>();

            IEnumerable<Utente> elencoUtenti = _repo.GetAll();
            foreach (Utente utente in elencoUtenti)
            {
                UtenteDTO temp = new UtenteDTO()
                {
                    CodUt = utente.CodiceUtente,
                    UsNa = utente.Username,
                    Pass = utente.Password,
                    Mail = utente.Email,
                    TipoUt = utente.TipoUtente,
                };

                risultato.Add(temp);
            }

            return risultato;
        }

        public bool Elimina(string codice)
        {
            bool risultato = false;

            Utente? ute = _repo.GetByCodice(codice);
            if (ute is not null)
                risultato = _repo.Delete(ute.UtenteID);

            return risultato;
        }

        public bool Inserisci(UtenteDTO entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.UsNa) && !string.IsNullOrWhiteSpace(entity.Mail) && !string.IsNullOrWhiteSpace(entity.Pass))
            {
                Utente ute = new Utente()
                {
                    CodiceUtente = entity.CodUt ?? Guid.NewGuid().ToString().ToUpper(),
                    Username = entity.UsNa,
                    Password = entity.Pass,
                    Email = entity.Mail,
                    TipoUtente = entity.TipoUt
                };

                return _repo.Create(ute);
            }

            return false;
        }

        public bool VerificaEmailPassword(UtenteDTO utenteDTO)
        {
            bool risultato = false;

            if (utenteDTO.Mail is not null && utenteDTO.Pass is not null)
            {
                Utente? utente = _repo.GetByEmailPassword(utenteDTO.Mail, utenteDTO.Pass);
                if (utente is not null)
                    risultato = true;
            }

            return risultato;
        }
    }
}
