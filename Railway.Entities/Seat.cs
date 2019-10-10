namespace Railways.Entities
{
    public class Seat
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int CarriageId { get; set; }

        public Carriage Carriage { get; set; }

        public int SeatTypeId { get; set; }

        public SeatType SeatType { get; set; }

        public Ticket Ticket { get; set; }
    }
}