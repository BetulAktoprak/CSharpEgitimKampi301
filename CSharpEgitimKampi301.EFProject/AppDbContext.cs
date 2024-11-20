using CSharpEgitimKampi301.EFProject.Entities;
using System.Data.Entity;

namespace CSharpEgitimKampi301.EFProject
{
    public class AppDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Location> Locations { get; set; }
        public AppDbContext() : base("name=EgitimKampiEfTravelDbEntities") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(c => c.Balance)
                .HasColumnType("decimal")
                .HasPrecision(18, 2);
            modelBuilder.Entity<Location>()
                .Property(l => l.Price)
                .HasColumnType("decimal")
                .HasPrecision(18, 2);
        }
    }
}
