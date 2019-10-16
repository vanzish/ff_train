namespace Railways.Entities.DTO.Options
{
    public class TicketsOptions
    {
        public int RunId { get; set; }

        public int DepartureCityId { get; set; }

        public int ArrivalCityId { get; set; }

        public int[] Seats { get; set; }
    }
}