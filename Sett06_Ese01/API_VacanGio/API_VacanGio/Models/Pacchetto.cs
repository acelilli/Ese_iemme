using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_VacanGio.Models
{
    [Table("Pacchetto_Vacanza")]
    public class Pacchetto
    {
        [Key]
        public int PacchettoID { get; set; }
        public string CodicePac { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public decimal Prezzo { get; set; } 
        public int Durata { get; set; } = 0;
        public DateOnly? DataInizio { get; set; }
        public DateOnly? DataFine { get; set; }

        public ICollection<DestinazionePacchetto>? DesPac { get; set; }
    }
}
