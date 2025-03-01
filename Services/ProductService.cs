using ProjektProgramia.DataAccess;
using ProjektProgramia.DataAccess.InterfaceRepository;
using ProjektProgramia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektProgramia.Services
{
    public class ProductService
    {
        private readonly IProductRepository productRepository;
        private readonly OrderService orderService;
        public ProductService(IProductRepository productRepository, OrderService orderService)
        {
            this.productRepository = productRepository;
            this.orderService = orderService;
        }
        public IEnumerable<Product> GetProducts()
        {
            return productRepository.GetProducts();
        }
        public bool RemoveProduct(int productId)
        {
            var product = productRepository.FindProduct(productId);
            if (product != null)
            {
                return productRepository.RemoveProduct(product);
            }
            return false;
        }
        public bool MakeOrder(int userId, int productId)
        {
           return orderService.MakeOrder(userId, productId);
        }

        public  Product FindProduct(int productId)
        {
            return productRepository.FindProduct(productId);
        }

        public bool AddProducts(Product product)
        {
            if (product != null)
            {
                productRepository.AddProduct(product);
                return SaveChanges();
            }
            return false;
        }

        public bool SaveChanges()
        {
            return productRepository.SaveChanges();
        }
    }
}