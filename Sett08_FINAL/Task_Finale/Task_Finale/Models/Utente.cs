using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Finale.Models
{
    [Table("Utente")]
    public class Utente
    {
        [Key]
        public int UtenteID { get; set; }

        [Column("codice_utente")]
        public string CodiceUtente { get; set; } = null!;

        [Required]
        public string Username { get; set; }

        [Column("psw")]
        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Column("tipo_utente")]
        public string TipoUtente { get; set; }


    }
}
