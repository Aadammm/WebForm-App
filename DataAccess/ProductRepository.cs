using WebForms.DataAccess.InterfaceRepository;
using WebForms.Models;
using WebForms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForms.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext dbContext;
        public ProductRepository()
        {
            dbContext = new ApplicationDbContext();
        }
        public bool AddProduct(Product product)
        {
            if (product != null)
            {
                dbContext.Products.Add(product);
                return SaveChanges();
            }
            return false;
        }

        public Product FindProduct(int productId)
        {
            if (productId != 0)
            {
                return dbContext.Products.Find(productId);
            }
            return null;
        }

        public IEnumerable<Product> GetProducts()
        {
            return dbContext.Products;
        }

        public bool RemoveProduct(Product product)
        {
            try
            {
                dbContext.Products.Remove(product);
                return SaveChanges();
            }
            catch
            {
                return false;
            }
        }

        public bool SaveChanges()
        {
            return dbContext.SaveChanges() > 0;
        }
    }
}