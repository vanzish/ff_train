using System;
using System.Collections.Generic;
using System.Text;

namespace Railways.Entities.DTO
{
    public class SeatDto
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public SeatTypeDto SeatType { get; set; }

        public bool IsBusy { get; set; }
    }
}