using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MunchAllotApp.Data;
using MunchAllotApp.Models;

namespace MunchAllotApp.Controllers
{
    public class AppController : Controller
    {
        
        private readonly IMunchAllotRepository _repository;
        private readonly ILogger<AppController> _logger;

        public AppController(IMunchAllotRepository repository,ILogger<AppController> logger)
        {
            
            _repository = repository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            var results = _repository.GetAllProducts();
            return View(results);
        }

      

        public IActionResult Orders()
        {
            
            return View();
        }


        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
