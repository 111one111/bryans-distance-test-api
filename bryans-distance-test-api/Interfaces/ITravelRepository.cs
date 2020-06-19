using bryans_distance_test_api.Models;
using System.Collections.Generic;

namespace bryans_distance_test_api.Interfaces
{
    public interface ITravelRepository
    {
        /// <summary>
        /// Saves to Database the Journey
        /// </summary>
        /// <param name="travelPoint"></param>
        void SaveVoyage(TravelPoints travelPoint);
        
        /// <summary>
        /// Gets all distances traveled.
        /// </summary>
        /// <returns></returns>
        List<TravelPoints> GetVoyages();
    }
}
