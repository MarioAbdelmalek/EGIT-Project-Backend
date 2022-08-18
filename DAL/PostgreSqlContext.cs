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
        public DbSet<Client> Clients { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {  
            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, UserName = "Mario_Abdelmalek", FirstName = "Mario", LastName = "Abdelmalek",
                Email = "mario.abdelmalek7@gmail.com", HomeAddress = "20 El Nozha Street", PhoneNumber = "01273615172",
                PassportNumber = "0933478", Password = "Abdelmalek_2000", IsAdmin = true, IsPowerUser = true }
            );
        }

    }
}
