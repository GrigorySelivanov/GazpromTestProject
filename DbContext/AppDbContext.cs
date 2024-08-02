using Data.Models;
using Microsoft.EntityFrameworkCore;
namespace DbContext
{
    public class AppDbContext(DbContextOptions options) : Microsoft.EntityFrameworkCore.DbContext(options)
    {
        public DbSet<Offer> Offers { get; set; } = null!;
        public DbSet<Provider> Providers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Offer>()
              .HasOne(r => r.Provider)
              .WithMany(e => e.Offers)
              .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Provider>()
              .HasMany(r => r.Offers)
              .WithOne(e => e.Provider)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
