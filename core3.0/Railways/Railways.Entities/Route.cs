using System.Collections.Generic;

namespace Railways.Entities
{
    public class Route
    {
        public Route()
        {
            RoutePoints = new List<RoutePoint>();
            Runs = new List<Run>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<RoutePoint> RoutePoints { get; set; }

        public ICollection<Run> Runs { get; set; }
    }
}