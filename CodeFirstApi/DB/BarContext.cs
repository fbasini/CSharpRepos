using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class BarContext : DbContext
    {
        public BarContext(DbContextOptions<BarContext> options) : base(options)
        {

        }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>().ToTable("Beer");
            modelBuilder.Entity<Brand>().ToTable("Brand");

            modelBuilder.Entity<Brand>().HasData(
                new Brand { BrandID = 2, Name = "Stella Artois" },
                new Brand { BrandID = 3, Name = "Heineken" }
            );

            modelBuilder.Entity<Beer>().HasData(
                new Beer { BeerID = 6, Name = "Golden", BrandID = 2 },
                new Beer { BeerID = 7, Name = "Ipa", BrandID = 3 }
            );
        }
    }
}
