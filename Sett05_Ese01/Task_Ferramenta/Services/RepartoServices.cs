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
            throw new NotImplementedException();
        }
    }
}
