using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using MunchAllotApp.Data.Entities;
using Newtonsoft.Json;

namespace MunchAllotApp.Data
{
    public class MunchAllotSeeder
    {
        private readonly MunchAllotContext _ctx;
        private readonly IHostEnvironment _hosting;

        public MunchAllotSeeder(MunchAllotContext ctx, IHostEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();
            if (!_ctx.Products.Any())
            {
                //Need to create sample
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/pizza.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _ctx.Products.AddRange(products);
                
                _ctx.SaveChanges();
            }
        }
    }
}
