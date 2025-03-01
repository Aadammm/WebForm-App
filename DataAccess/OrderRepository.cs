using ProjektProgramia.DataAccess.InterfaceRepository;
using ProjektProgramia.Models;
using ProjektProgramia.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace ProjektProgramia.DataAccess
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext dbContext;
        public OrderRepository()
        {
            dbContext = new ApplicationDbContext();
        }

        public bool AddOrder(Order order)
        {
            if (order != null)
            {
                dbContext.Orders.Add(order);
                return SaveChanges();
            }
            return false;
        }

        public Product FindProduct(int productId)
        {
            return dbContext.Products.Find(productId);
        }

        public IEnumerable<Order> GetOrders()
        {
            return dbContext.Orders;
        }

        public bool SaveChanges()
        {
            return dbContext.SaveChanges() > 0;
        }
    }
}