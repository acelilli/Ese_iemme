using API_VacanGio.Context;
using API_VacanGio.Models;
using API_VacanGio.Repositories;

namespace API_VacanGio.Services
{
    public class DestinazioneServices : IServices<DestinazioneDTO>
    {
        private readonly DestinazioneRepo _repository;

        public DestinazioneServices(DestinazioneRepo repo)
        {
            _repository = repo;
        }
        public bool Aggiorna(DestinazioneDTO entity)
        {
            throw new NotImplementedException();
        }

        public DestinazioneDTO? CercaPerCodice(string codice)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DestinazioneDTO> CercaTutti()
        {
            ICollection<DestinazioneDTO> risultato = new List<DestinazioneDTO>();

            IEnumerable<Destinazione> elencoDestinazioni = _repository.GetAll();
            foreach (Destinazione destinazione in elencoDestinazioni)
            {
                DestinazioneDTO temp = new DestinazioneDTO()
                {
                    CodDes = destinazione.CodiceDes,
                    Nom = destinazione.Nome,
                    Desc = destinazione.Descrizione,
                    Pae = destinazione.Paese,
                    ImU = destinazione.ImgURL,
                };

                risultato.Add(temp);
            }

            return risultato;
        }

        public bool Elimina(string codice)
        {
            throw new NotImplementedException();
        }

        public bool Inserisci(DestinazioneDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
