using System;
using System.Collections.Generic;
using System.Text;

namespace Railways.Entities.DTO
{
    public class CarriageDto
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public IEnumerable<SeatDto> Seats { get; set; }
    }
}