using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bryans_distance_test_api.Models
{
    public class TravelPoints
    {
        public string LocationId { get; set; }
        public double TraveledDistance { get; set; }
        public List<Point> Points { get; set; }
    }
}
