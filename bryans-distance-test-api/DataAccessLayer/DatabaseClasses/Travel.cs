
using System.Collections.Generic;

namespace bryans_distance_test_api.DataAccessLayer.DatabaseClasses
{
    public class Travel
    {
        public int Id { get; set; }
        public string LocationId { get; set; }
        public double TotalKm { get; set; }
        public ICollection<Coordinates> Coordinates { get; set;}
    }
}
