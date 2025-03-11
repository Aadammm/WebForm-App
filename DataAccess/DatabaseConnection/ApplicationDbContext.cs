using WebForms.Models;
using System.Data.Entity;

namespace WebForms.Services
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
              .HasRequired(u => u.Address)      
              .WithMany()                       
              .HasForeignKey(u => u.AddressId);


            modelBuilder.Entity<Order>()
                .HasRequired(o => o.User)       
                .WithMany(u => u.Orders)        
                .HasForeignKey(o => o.UserId);


            modelBuilder.Entity<Order>()
                .HasRequired(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}