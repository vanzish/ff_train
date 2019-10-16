using System;
using System.Collections.Generic;
using System.Text;

namespace Railways.Entities.DTO
{
    public class SeatTypeDto
    {
        public SeatPositionEnum Position { get; set; }

        public bool IsOutboard { get; set; }
    }
}