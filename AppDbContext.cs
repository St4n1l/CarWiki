using Microsoft.EntityFrameworkCore;

namespace CarWiki
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=carWikiDb;Username=postgres;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("cars");
                entity.HasKey(c => c.id);
                entity.Property(c => c.make).IsRequired();
                entity.Property(c => c.model).IsRequired();
                entity.Property(c => c.year).IsRequired();
                entity.Property(c => c.horsePower).IsRequired();
                entity.Property(c => c.imagePath);
            });
        }
    }
}
