
using bryans_distance_test_api.DataAccessLayer.DatabaseClasses;
using bryans_distance_test_api.Interfaces;
using bryans_distance_test_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace bryans_distance_test_api.DataAccessLayer.Repositories
{
    public class TravelRepository : ITravelRepository
    {
        internal DataContext _context;

        public TravelRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Saves to Database the Journey
        /// </summary>
        /// <param name="travelPoint"></param>
        public void SaveVoyage(TravelPoints travelPoint)
        {
            Travel travel = new Travel {
                LocationId = travelPoint.LocationId,
                TotalKm = travelPoint.TraveledDistance,
                Coordinates = new List<Coordinates>()
            };

            travelPoint.Points.ForEach(point => {
                travel.Coordinates.Add(new Coordinates() { 
                    Latitude = point.Latitude,
                    Longitude = point.Longitude
                });
            });
            _context.Travel.Add(travel);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all distances traveled.
        /// </summary>
        /// <returns></returns>
        public List<TravelPoints> GetVoyages()
        {
            var travelPoints = new List<TravelPoints>();
            var traveled = _context.Travel.Include(table => table.Coordinates).ToList();
            traveled.ForEach(tra => {
                var travel = new TravelPoints();
                travel.LocationId = tra.LocationId;
                travel.TraveledDistance = tra.TotalKm;
                travel.Points = new List<Point>();
                tra.Coordinates.ToList().ForEach(coord => {
                    travel.Points.Add(new Point() { 
                        Latitude = coord.Latitude, 
                        Longitude = coord.Longitude 
                    });
                });
                travelPoints.Add(travel);
            });

            return travelPoints;
        }
    }
}
