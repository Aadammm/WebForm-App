﻿using WebForms.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace WebForms.DataAccess.InterfaceRepository
{
    public interface IProductRepository
    {
        bool AddProduct(Product product);
        Product FindProduct(int productId);
        IEnumerable<Product> GetProducts();
        bool SaveChanges();
        bool RemoveProduct(Product product);
    }
}
