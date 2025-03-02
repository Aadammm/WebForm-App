using ProjektProgramia.Models;
using System.Data.Entity;

namespace ProjektProgramia.Services
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public ApplicationDbContext() : base("name=MyLocalDbContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {        
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
}