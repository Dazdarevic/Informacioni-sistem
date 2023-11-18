using Microsoft.EntityFrameworkCore;

namespace Informacioni_sistemi___Projekat.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<AdvertisingPanel> AdvertisingPanels { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CityArea> CityAreas { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdvertisingPanel>()
                .HasOne(a => a.City)        // AdvertisingPanel ima jedan City
                .WithMany(c => c.AdvertisingPanels)  // City ima više AdvertisingPanel-ova
                .HasForeignKey(a => a.CityID);
        }
    }
}
