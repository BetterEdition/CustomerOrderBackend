using CustomerSystemDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerSystemDAL.Context
{
    public class EASVContext : DbContext
    {
        public EASVContext(DbContextOptions<EASVContext> options) : base(options) { }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}