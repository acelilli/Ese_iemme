using API_VacanGio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace API_VacanGio.Context
{
    public class VaContext : DbContext
    {
        public VaContext(DbContextOptions<VaContext> options ) : base(options) 
        {

        }

        public DbSet<Destinazione> Destinazioni { get; set; }
        public DbSet<Pacchetto> Pacchetti { get; set; }
        public DbSet<DestinazionePacchetto> DestPacchettos { get; set; }

        public DbSet<Recensione> Recensioni { get; set; }
    }
}
