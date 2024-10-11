using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.Xml;
using Task_Ferramenta.Models;
using Task_Ferramenta.Repos;

namespace Task_Ferramenta.Services
{
    public class RepartoServices : IServices<RepartoDTO>
    {
        // DEVI FARE I DTO
        //IServices<Reparto>

        private readonly RepartoRepo _repository;

        public RepartoServices(RepartoRepo repository)
        {
            _repository = repository;
        }
        public RepartoDTO? Cerca(string varCod)
        {
            RepartoDTO? risultato = null;

            Reparto? rep = _repository.GetByCodice(varCod);
            if (rep != null)
            {
                risultato = new RepartoDTO()
                {
                    RepCOD = rep.RepartoCOD,
                    Nom = rep.Nome,
                    Fil = rep.Fila,
                };
            }

            return risultato;
        }

        public IEnumerable<RepartoDTO> Lista()
        {
            var repDTOS = new List<RepartoDTO>();
            IEnumerable<Reparto> elenco = _repository.GetAll();
            foreach (var rep in elenco)
            {
                RepartoDTO temp = new RepartoDTO()
                {
                    RepCOD = rep.RepartoCOD,
                    Nom = rep.Nome,
                    Fil = rep.Fila
                };
                repDTOS.Add(temp);
            }

            return repDTOS;
        }

        public bool InserisciReparto(RepartoDTO repDTO)
        {
            bool risultato = false;
            if (!string.IsNullOrWhiteSpace(repDTO.Nom) && !string.IsNullOrWhiteSpace(repDTO.Fil))
            {
                Reparto rep = new Reparto()
                {
                    RepartoCOD = repDTO.RepCOD is not null ? repDTO.RepCOD : Guid.NewGuid().ToString().ToUpper(),
                    Nome = repDTO.Nom,
                    Fila = repDTO.Fil
                };

                return risultato = _repository.Create(rep);
            }

            return risultato;
        }

        public bool EliminaReparto(RepartoDTO repDTO) 
        {
            bool risultato = false;
            if (!string.IsNullOrWhiteSpace(repDTO.RepCOD))
            { 

            Reparto? rep = _repository.GetByCodice(repDTO.RepCOD);

                if (rep != null)
                {
                    risultato = _repository.Delete(rep.RepartoID);
                }
                else {
                    Console.WriteLine("Cancellazione bloccata in Services");
                }
            }

            return risultato;
        }
    }
}
