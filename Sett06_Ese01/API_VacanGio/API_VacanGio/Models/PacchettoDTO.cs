using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_VacanGio.Models
{
    public class PacchettoDTO
    {
        public string CodPac { get; set; } = null!;
        public string Nom { get; set; } = null!;
        public decimal Pre { get; set; } 
        public int Dur { get; set; } = 0;
        public DateOnly? DaIn { get; set; }
        public DateOnly? DaFi { get; set; }

        // Lo implementeremo? Può esse.
        //public IEnumerable<DestinazioneDTO> Destinazioni { get; set; }
    }
}
