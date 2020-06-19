using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bryans_distance_test_api.Models;
using bryans_distance_test_api.Interfaces;

namespace bryans_distance_test_api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITravelBusiness _travel;

        public HomeController(ILogger<HomeController> logger, ITravelBusiness travel)
        {
            _travel = travel;      
            _logger = logger;
        }

        public ActionResult Index()
        {
            var result = _travel.GetTravelPoints();
            return View(result);
        }       
    }
}
