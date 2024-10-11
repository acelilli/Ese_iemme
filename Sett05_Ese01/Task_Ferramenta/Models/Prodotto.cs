using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Ferramenta.Models
{
    [Table("Prodotto")]
    public class Prodotto
    {
        /*
         * prodottoID INT PRIMARY KEY IDENTITY(1,1),
	        codiceBarre VARCHAR(250) NOT NULL UNIQUE,
	        nome VARCHAR(250) NOT NULL,
	        descrizione TEXT,
	        prezzo DECIMAL(5,3),
	        quantita INT NOT NULL CHECK (quantita >= 0),
	        repartoRIF INT NOT NULL,
         */

        public int ProdottoID { get; set; }
        public string CodiceBarre { get; set; }
        public string Nome { get; set; }
        public string? Descrizione { get; set; } 
        public decimal Prezzo { get; set; }
        public int Quantita { get; set; }
        public int RepartoRIF { get; set; }
    }
}
