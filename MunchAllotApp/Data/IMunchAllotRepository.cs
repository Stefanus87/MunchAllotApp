using System.Collections.Generic;
using MunchAllotApp.Data.Entities;

namespace MunchAllotApp.Data
{
    public interface IMunchAllotRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsCategory(string category);
        bool SaveAll();
        IEnumerable<Order> GetAllOrders();
        
        void AddEntity(object model);
        IEnumerable<Product> GetProductById(int id);
    }
}