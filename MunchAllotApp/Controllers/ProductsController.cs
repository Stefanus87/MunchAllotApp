using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MunchAllotApp.Data;
using MunchAllotApp.Data.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MunchAllotApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IMunchAllotRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IMunchAllotRepository repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _repository.GetAllProducts();
        }

        
        [HttpPost("{id}")]
        public IEnumerable<Product> GetProductById(int id)
        {
            return _repository.GetProductById(id);
        }


    }
}
