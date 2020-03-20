using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MunchAllotApp.Data.Entities;

namespace MunchAllotApp.Data
{

    public class MunchAllotRepository : IMunchAllotRepository
    {
        private readonly MunchAllotContext _ctx;

        public MunchAllotRepository(MunchAllotContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _ctx.Products
                .OrderBy(p => p.Name)
                .ToList();
        }

        public IEnumerable<Product> GetProductsCategory(string category)
        {
            return _ctx.Products
                .Where(p => p.Category == category)
                .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _ctx.Orders.ToList();
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<Product> GetProductById(int id)
        {
            return _ctx.Products
                .Where(p => p.Id == id)
                .ToList();
        }

    }
}
