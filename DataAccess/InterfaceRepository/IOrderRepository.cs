﻿using WebForms.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebForms.DataAccess.InterfaceRepository
{
    public interface IOrderRepository
    {
        bool AddOrder(Order order);
        bool SaveChanges();
        IEnumerable<Order> GetOrders();
        Product FindProduct(int productId);
    }
}
