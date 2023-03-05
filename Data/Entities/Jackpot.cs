using System.ComponentModel.DataAnnotations;

namespace Toto_Simulator.Data.Entities
{
    public class Jackpot
    {
        [Key]
        public int Id { get; set; }
        public decimal AccumulatedSum { get; set; }
    }
}
