using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Ferramenta.Models
{
    [Table("Reparto")]
    public class Reparto
    {
        /* 
         * repartoID INT PRIMARY KEY IDENTITY(1,1),
	        repartoCOD VARCHAR(250) NOT NULL UNIQUE,
	        nome VARCHAR(250) NOT NULL, 
	        fila VARCHAR(10) NOT NULL,
         */
        public int RepartoID { get; set; }
        public string RepartoCOD { get; set; } = null!;
        public string? Nome { get; set; }
        public string? Fila { get; set; }

    }
}
