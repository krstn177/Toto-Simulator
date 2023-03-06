using System.ComponentModel.DataAnnotations;
using Toto_Simulator.Data.Entities;

namespace Toto_Simulator.Models
{
    public class TicketFormModel
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 5,
            ErrorMessage = "Цената за билет трябва да е между 1 и 5 лева")]
        public decimal Price { get; set; }
        

        [Required]
        [Range(1, 49)]
        public int First { get; set; }

        [Required]
        [Range(1, 49)]
        public int Second { get; set; }

        [Required]
        [Range(1, 49)]
        public int Third { get; set; }

        [Required]
        [Range(1, 49)]
        public int Fourth { get; set; }

        [Required]
        [Range(1, 49)]
        public int Fifth { get; set; }

        [Required]
        [Range(1, 49)]
        public int Sixth { get; set; }

    }
}
