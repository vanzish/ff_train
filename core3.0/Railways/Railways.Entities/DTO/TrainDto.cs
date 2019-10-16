using System.Collections.Generic;

namespace Railways.Entities.DTO
{
    public class TrainDto
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public IEnumerable<CarriageDto> Carriages { get; set; }
    }
}