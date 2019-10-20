using System.Collections.Generic;

namespace Railways.Entities.DTO.Results
{
    public class TicketsResult
    {
        public IEnumerable<TicketDto> Tickets { get; set; }

        public IEnumerable<string> PlacesToBuy { get; set; }
    }
}