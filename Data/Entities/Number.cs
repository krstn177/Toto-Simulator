namespace Toto_Simulator.Data.Entities
{
    public class Number
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int Ocurrences { get; set; }

        public virtual ICollection<Draw> Draws { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
