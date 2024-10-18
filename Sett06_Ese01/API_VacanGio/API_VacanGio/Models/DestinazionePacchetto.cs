using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_VacanGio.Models
{
    [Table("Destinazione_Pacchetto")]
    public class DestinazionePacchetto
    {
        [Key]
        public int Destinazione_PacchettoID { get; set; }

        public int DestinazioneRIF { get; set; }
        public Destinazione? Dest { get; set; }
        
        public int PacchettoRIF { get; set; }
        public Pacchetto? Pacc { get; set; }
    }
}
