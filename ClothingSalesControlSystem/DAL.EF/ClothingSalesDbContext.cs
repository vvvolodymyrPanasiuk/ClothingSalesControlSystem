using ClothingSalesControlSystem.DAL.EF.DbConfigurations;
using ClothingSalesControlSystem.Domain.Entities.ClothingAggregate;
using ClothingSalesControlSystem.Domain.Entities.OrderAggregate;
using ClothingSalesControlSystem.Domain.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace ClothingSalesControlSystem.DAL.EF
{
    public class ClothingSalesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<TShirt> TShirts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ClothingSalesDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TShirtConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
