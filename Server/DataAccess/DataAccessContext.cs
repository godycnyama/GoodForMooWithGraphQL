using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using GoodForMoo.Server.DataModels;

namespace GoodForMoo.Server.DataAccess
{
    public class DataAccessContext: DbContext
    {
        public DataAccessContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@Environment.GetEnvironmentVariable("MOOR_DBCONNECT"));
        }
        */
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>();
            //builder.Entity<Order>().OwnsMany(p => p.OrderDetails);
            //builder.Entity<Order>().Property(p => p.Total).HasColumnType("decimal(65,2)");
            //builder.Entity<Product>().Property(p => p.UnitPrice).HasColumnType("decimal(65,2)");
            builder.Entity<Customer>().HasIndex(u => u.CustomerName).IsUnique();
            builder.Entity<Order>().HasIndex(u => u.CustomerID);
            builder.Entity<Product>().HasIndex(u => u.ProductName).IsUnique();
        }

    }
}
