using System;

namespace Railways.Entities
{
    public class Run
    {
        public int Id { get; set; }

        public DateTime RunTime { get; set; }

        public int RouteId { get; set; }

        public Route Route { get; set; }
    }
}
