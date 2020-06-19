using bryans_distance_test_api.Interfaces;
using bryans_distance_test_api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace bryans_distance_test_api.Controllers
{
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        ITravelBusiness _travel;
        public LocationController(ITravelBusiness travel)
        {
            _travel = travel;
        }
        public IActionResult Index()
        {            
            return Ok();
        }

        [Route("submitcoordinates")]
        [HttpPost]
        public IActionResult SubmitCoordinates([FromBody]List<LocationModel> coordinates)
        {
            _travel.SaveTripData(coordinates);
            return Ok();
        }
    }
}