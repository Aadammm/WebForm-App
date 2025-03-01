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
        private readonly IOrderRepository orderRepository;
        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
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
            Order newOrder = new Order()
            {
                ProductId = productId,
                UserId = userId
            };
            return orderRepository.AddOrder(newOrder);
        }

    }
}