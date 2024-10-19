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
            bool risultato = false;

            if(entity.CodDes is not null) 
            {
                Destinazione? des = _repository.GetByCodice(entity.CodDes);
                if (des != null && entity.Nom is not null && entity.Nom is not null) 
                {
                    des.CodiceDes = entity.CodDes is not null ? entity.CodDes : des.CodiceDes;
                    des.Nome = entity.Nom is not null ? entity.Nom : des.Nome;
                    des.Descrizione = entity.Desc is not null ? entity.Desc : des.Descrizione;
                    des.Paese = entity.Pae is not null ? entity.Pae : des.Paese;
                    des.ImgURL = entity.ImU is not null ? entity.ImU : des.ImgURL;

                    risultato = true;
                }
            }

            return risultato;
        }

        public DestinazioneDTO? CercaPerCodice(string codice)
        {
           DestinazioneDTO? destRicercata = null;

            Destinazione? dest = _repository.GetByCodice(codice);
            if (dest is not null) 
            {
                destRicercata = new DestinazioneDTO()
                {
                    CodDes = dest.CodiceDes,
                    Nom = dest.Nome,
                    Desc = dest.Descrizione,
                    Pae = dest.Paese,
                    ImU = dest.ImgURL,
                };
            }

            return destRicercata;
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
            bool risultato = false;

            Destinazione? dest = _repository.GetByCodice(codice);
            if(dest is not null)
                risultato = _repository.Delete(dest.DestinazioneID);

            return risultato;
        }

        public bool Inserisci(DestinazioneDTO entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.Nom) && !string.IsNullOrWhiteSpace(entity.Pae))
            {
                Destinazione dest = new Destinazione()
                {
                    CodiceDes = entity.CodDes ?? Guid.NewGuid().ToString().ToUpper(), // Usa ?? invece di is not null
                    Nome = entity.Nom,
                    Descrizione = entity.Desc,
                    Paese = entity.Pae,
                    ImgURL = entity.ImU
                };

                return _repository.Create(dest);  // Restituisci direttamente
            }

            return false;
        }
    }
}
