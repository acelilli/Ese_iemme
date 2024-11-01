using Microsoft.EntityFrameworkCore;

namespace Task_Finale.Models
{
    public class Task_FinaleContext : DbContext
    {
        public Task_FinaleContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Utente> Utenti { get; set; }
    }
}
