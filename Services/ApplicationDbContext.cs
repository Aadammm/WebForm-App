using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ProjektProgramia.Services
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext() : base("name=ConnectionString")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
              .HasRequired(u => u.Address)      // Každý User má povinnú Address
              .WithMany()                       // Jedna Address môže mať viacero Users
              .HasForeignKey(u => u.AddressId); // Cudzí kľúč je AddressId v User

            // Vzťah medzi User a Product
            modelBuilder.Entity<User>()
                .HasRequired(u => u.Product)     // Každý User má povinný Product
                .WithMany()                       // Jeden Product môže mať viacero Users
                .HasForeignKey(u => u.ProductId); // Cudzí kľúč je ProductId v User

            base.OnModelCreating(modelBuilder);


        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
    }
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }



}