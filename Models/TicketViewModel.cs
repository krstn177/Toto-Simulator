using Toto_Simulator.Data.Entities;

namespace Toto_Simulator.Models
{
    public class TicketViewModel
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }

        public int DrawId { get; set; }
        
        public User Owner { get; init; }

        public List<Number> Numbers { get; set; } = new List<Number>(6);
       
}
}
