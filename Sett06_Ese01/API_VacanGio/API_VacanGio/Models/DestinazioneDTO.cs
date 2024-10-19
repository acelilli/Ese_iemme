using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_VacanGio.Models
{
    public class DestinazioneDTO
    {
        public string? CodDes { get; set; }
        public string Nom { get; set; } = null!;
        public string? Desc { get; set; }
        public string Pae { get; set; } = null!;
        public string ImU { get; set; } = null!;

    }
}
