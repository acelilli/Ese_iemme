using Task_Ferramenta.Models;
using Task_Ferramenta.Repos;

namespace Task_Ferramenta.Services
{
    public class ProdottoServices : IServices<ProdottoDTO>
    {
        private readonly ProdottoRepo _repository;

        public ProdottoServices(ProdottoRepo repository)
        {
            _repository = repository;
        }
        public ProdottoDTO? Cerca(string varCod)
        {
            ProdottoDTO? risultato = null;

            Prodotto? pro = _repository.GetByCodice(varCod);
            if (pro != null)
            {
                risultato = new ProdottoDTO()
                {
                    CodBa = pro.CodiceBarre,
                    Nom = pro.Nome,
                    Desc = pro.Descrizione,
                    Pre = pro.Prezzo,
                    Quan = pro.Quantita,
                };
            }

            return risultato;
        }

        public IEnumerable<ProdottoDTO> Lista()
        {
            throw new NotImplementedException();
        }
    }
}
