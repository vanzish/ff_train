using System;
using System.Collections.Generic;

namespace Railways.Entities.DTO
{
    public class RunDto
    {
        public int Id { get; set; }

        public DateTime RunTime { get; set; }

        public RouteDto Route { get; set; }

        public TrainDto Train { get; set; }
    }
}