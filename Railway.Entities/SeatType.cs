namespace Railways.Entities
{
    public class SeatType
    {
        public int Id { get; set; }

        public SeatPositionEnum Position { get; set; }

        public bool IsOutboard { get; set; }

        public Seat Seat { get; set; }
    }
}