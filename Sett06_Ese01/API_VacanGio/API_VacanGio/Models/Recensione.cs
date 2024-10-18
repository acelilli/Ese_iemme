using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_VacanGio.Models
{
    [Table("Recensione")]
    public class Recensione
    {
        [Key]
        public int RecensioneID { get; set; }
        public string CodicePac { get; set; } = null!;
        public string NomeUtente { get; set; } = null!;
        public int Voto { get; set; }
        public string? Commento { get; set; }
        public DateOnly? DataRece { get; set; }
        public int PacchettoRIF { get; set; }
        public Pacchetto? Pacc { get; set; }
    }
}
