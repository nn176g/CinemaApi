using Microsoft.EntityFrameworkCore;

namespace Store.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext()
        {
        }
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options)
        { }

        public DbSet<Store.Data.Models.Cinemas> Cinemas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=Store.DB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
    }
}
