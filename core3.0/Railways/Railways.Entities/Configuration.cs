using System;

namespace Railways.Entities
{
    public class Configuration
    {
        public int Id { get; set; }
        public string ConfigName { get; set; }
        public TimeSpan CancelReservationOffset { get; set; }
    }
}