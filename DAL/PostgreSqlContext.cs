using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }

        public DbSet<Cluster> Clusters { get; set; }
        public DbSet<Lun> Luns { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Seed();
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }

    public static class ModelBuilderExtensions
    {
/*        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().HasData(
                new Stock { ID = 1, Name = "APPL", Price = 1000 },
                new Stock { ID = 2, Name = "BAC", Price = 2000 },
                new Stock { ID = 3, Name = "ROCK", Price = 3000 },
                new Stock { ID = 4, Name = "FUN", Price = 4000 },
                new Stock { ID = 5, Name = "AVCTW", Price = 5000 }
            );

            modelBuilder.Entity<Person>().HasData(
               new Person { ID = 1, Name = "Mario", BrokerID = 2 },
               new Person { ID = 2, Name = "Mark", BrokerID = 2 },
               new Person { ID = 3, Name = "Ali", BrokerID = 4 },
               new Person { ID = 4, Name = "Fady", BrokerID = 3 },
               new Person { ID = 5, Name = "Tarek", BrokerID = 3 }
            );

            modelBuilder.Entity<Broker>().HasData(
               new Broker { ID = 1, Name = "Marwan" },
               new Broker { ID = 2, Name = "George" },
               new Broker { ID = 3, Name = "Youssef" },
               new Broker { ID = 4, Name = "Nadim" },
               new Broker { ID = 5, Name = "Begad" }
            );

        }*/

    }
}
