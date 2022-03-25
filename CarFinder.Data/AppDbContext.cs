namespace CarFinder.Data
{
    using Microsoft.EntityFrameworkCore;
    using CarFinder.Models;
    public class AppDbContext : DbContext
    {
        private const string ConnectionString = "Server=localhost;Database=cardatabase;Trusted_Connection=True;";
        public virtual DbSet<Cars> Cars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
                optionsBuilder.UseLazyLoadingProxies();
            }
        }
    }
}
