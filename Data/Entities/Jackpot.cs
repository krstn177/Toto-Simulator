using System.ComponentModel.DataAnnotations;

namespace Toto_Simulator.Data.Entities
{
    public class Jackpot
    {
        [Key]
        public int Id { get; set; }
        [Range(0.00, double.MaxValue, ErrorMessage = "Фонда трябва да е положително число")]
        public decimal AccumulatedSum { get; set; }
    }
}
