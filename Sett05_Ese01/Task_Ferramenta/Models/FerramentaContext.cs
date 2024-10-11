using Microsoft.EntityFrameworkCore;

namespace Task_Ferramenta.Models
{
    public class FerramentaContext : DbContext
    {
        //opzioni personalizzate del dbContext
        public FerramentaContext(DbContextOptions<FerramentaContext> options) : base(options) { }

        //// scaffolding manuale di tutti i models
        public DbSet<Reparto> Reparto { get; set; }
        public DbSet<Prodotto> Prodotto { get; set; }
    }
}
