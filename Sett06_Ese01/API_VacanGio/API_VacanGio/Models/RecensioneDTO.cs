using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_VacanGio.Models
{
    public class RecensioneDTO
    {
        public string CodePac { get; set; } = null!;
        public string NoUt { get; set; } = null!;
        public int Vo { get; set; }
        public string? Com { get; set; }
        public DateOnly? DaRe { get; set; }
        public int PaccRIF { get; set; }
        public Pacchetto? Pacc { get; set; }
    }
}
