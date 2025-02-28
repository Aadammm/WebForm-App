using System;
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
        public DbSet<Order> Orders { get; set; }
        public ApplicationDbContext() : base("name=ConnectionString")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //// Vzťah medzi User a Product
            modelBuilder.Entity<User>()
              .HasRequired(u => u.Address)        // kazdy user ma addressu
              .WithMany()                        // Jedna adresa môže mať viacero používateľov
              .HasForeignKey(u => u.AddressId); // Cudzí kľúč je AddressId v User

            // Vzťah User - Order (Používateľ môže mať viac objednávok)
            modelBuilder.Entity<Order>()
                .HasRequired(o => o.User)           // Každá objednávka má používateľa
                .WithMany(u => u.Orders)           // Používateľ môže mať viac objednávok
                .HasForeignKey(o => o.UserId);           // Cudzí kľúč je UserId v Order


            // Vzťah OrderItem - Product (Položka objednávky odkazuje na produkt)
            modelBuilder.Entity<Order>()
                .HasRequired(oi => oi.Product)      // Každá položka objednávky má produkt
                .WithMany()                         // Produkt môže byť v mnohých položkách
                .HasForeignKey(oi => oi.ProductId); // Cudzí kľúč je ProductId v OrderItem


            base.OnModelCreating(modelBuilder);


        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
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
        public string Description { get; set; }

        public decimal Price { get; set; }
    }
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Order()
        {
            OrderDate = DateTime.Now;
        }
    }


}