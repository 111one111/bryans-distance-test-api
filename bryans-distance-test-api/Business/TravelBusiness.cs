using bryans_distance_test_api.Interfaces;
using bryans_distance_test_api.Models;
using GeoCoordinatePortable;
using System.Collections.Generic;

namespace bryans_distance_test_api.Business
{
    public class TravelBusiness : ITravelBusiness
    {
        readonly ITravelRepository _travelRepository;
        public TravelBusiness(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }

        /// <summary>
        /// Saves the trip/Calculates distance
        /// </summary>
        /// <param name="trip"></param>
        public void SaveTripData(List<LocationModel> trip)
        {
            var travel = SetTravelPoints(trip);
            travel.TraveledDistance = CalculateDistance(trip);
            _travelRepository.SaveVoyage(travel);
        }


        /// <summary>
        /// Sets Travel points
        /// </summary>
        /// <param name="trip"></param>
        /// <returns></returns>
        public TravelPoints SetTravelPoints(List<LocationModel> trip)
        {
            var traveled = new TravelPoints();
            traveled.LocationId = trip[0].Id;
            traveled.Points = new List<Point>();

            trip.ForEach(point => {
                traveled.Points.Add(new Point() {
                    Latitude = point.lat,
                    Longitude = point.lng
                });
            });

            return traveled;
        }

        /// <summary>
        /// Calculates Distance
        /// </summary>
        /// <param name="trip"></param>
        /// <returns></returns>
        public double CalculateDistance(List<LocationModel> trip)
        {
            double answer = 0;
            var lastCoord = new GeoCoordinate(trip[0].lat, trip[0].lng);
            trip.ForEach(tri => {
                var newCoord = new GeoCoordinate(tri.lat, tri.lng);
                var distance = lastCoord.GetDistanceTo(newCoord);
                lastCoord = newCoord;
                answer += distance;
            });

            if (answer == 0)
                return answer;
            else
                return answer / 1000;
        }

        /// <summary>
        /// Gets all Travel Points
        /// </summary>
        /// <returns></returns>
        public List<TravelPoints> GetTravelPoints()
        {
            return _travelRepository.GetVoyages();
        }
    }
}
