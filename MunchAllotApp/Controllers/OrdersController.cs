using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MunchAllotApp.Data;
using MunchAllotApp.Data.Entities;

namespace MunchAllotApp.Controllers
{
    [Route ("api/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMunchAllotRepository _repository;

        public OrdersController(IMunchAllotRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return  Ok(_repository.GetAllOrders());
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to retrieve Orders:" + ex);
                return BadRequest("Failed to retrieve Orders");
            }
            
        }

        [HttpPost]
        public IActionResult Post([FromBody]Order model)
        {
            try
            {
                _repository.AddEntity(model);

                if (_repository.SaveAll())
                {
                    return Created($"/api/orders/{model.Id}", model);
                }

               
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save Order:" + ex);
            }

            return BadRequest("Failed to save new Order");
        }
    }
}