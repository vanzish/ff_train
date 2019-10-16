using System.Collections.Generic;

namespace Railways.Entities
{
    public class Train
    {
        public Train()
        {
            Carriages = new List<Carriage>();
        }

        public int Id { get; set; }

        public string Number { get; set; }

        public Run Run { get; set; }

        public ICollection<Carriage> Carriages { get; set; }
    }
}