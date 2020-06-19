
using System.ComponentModel.DataAnnotations.Schema;

namespace bryans_distance_test_api.DataAccessLayer.DatabaseClasses
{
    public class Coordinates
    {
        public int Id { get; set; }

        [ForeignKey("TravelId")]
        public int TravelId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Travel Travel { get; set; }
    }
}
