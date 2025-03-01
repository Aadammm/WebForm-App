using ProjektProgramia.DataAccess.InterfaceRepository;
using ProjektProgramia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektProgramia.Services
{
    public class OrderService
    {
        private readonly IOrderRepository orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public IEnumerable<Order> GetOrdersBelongUser(int userId)
        {
            return orderRepository.GetOrders().Where(o => o.UserId == userId);
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