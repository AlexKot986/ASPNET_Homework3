using Microsoft.EntityFrameworkCore;

namespace StorageFacility.Contexts
{
    public class StorageFacilityContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public StorageFacilityContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine)
                .UseNpgsql("Host=localhost;Port=5433;Username=postgres;Password=example;Database=StorageFacility");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id).HasName("product_pkey");
                entity.ToTable("Products");
                entity.HasIndex(e => e.ProductId).IsUnique();
                entity.Property(e => e.ProductId).HasColumnName("productId");
                entity.Property(e => e.Count).HasColumnName("count");

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
