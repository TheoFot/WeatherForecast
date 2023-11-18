using Microsoft.EntityFrameworkCore;
using WeatherForecast.Models;

namespace WeatherForecast.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
      
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Weather> Weather { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //konfiguracja jeden do wielu
           
            modelBuilder.Entity<City>()
                .HasMany(w => w.Weathers)
                .WithOne(c => c.City)
                .HasForeignKey(c => c.CitiId);


        }
    }
}
