using bryans_distance_test_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bryans_distance_test_api.Interfaces
{
    public interface ITravelBusiness
    {
        /// <summary>
        /// Saves the trip/Calculates distance
        /// </summary>
        /// <param name="trip"></param>
        void SaveTripData(List<LocationModel> trip);

        /// <summary>
        /// Gets all Travel Points
        /// </summary>
        /// <returns></returns>
        List<TravelPoints> GetTravelPoints();
    }
}
