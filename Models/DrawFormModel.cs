using System.ComponentModel.DataAnnotations;

namespace Toto_Simulator.Models
{
    public class DrawFormModel
    {
        public int Id { get; set; }

        [Required]
        [Range(0.00, double.MaxValue, ErrorMessage = "Фонда трябва да е положително число")]
        public decimal Fund { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Победителите трябва да са положително число")]
        public int FirstGroupWinners { get; set; }

        [Required]
        [Range(0.00, double.MaxValue, ErrorMessage = "Сумата трябва да е положително число")]
        public decimal FirstGroupSum { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Победителите трябва да са положително число")]
        public int SecondGroupWinners { get; set; }

        [Required]
        [Range(0.00, double.MaxValue, ErrorMessage = "Сумата трябва да е положително число")]
        public decimal SecondGroupSum { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Победителите трябва да са положително число")]
        public int ThirdGroupWinners { get; set; }

        [Required]
        [Range(0.00, double.MaxValue, ErrorMessage = "Сумата трябва да е положително число")]
        public decimal ThirdGroupSum { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Победителите трябва да са положително число")]
        public int FourthGroupWinners { get; set; }

        [Required]
        [Range(0.00, double.MaxValue, ErrorMessage = "Сумата трябва да е положително число")]
        public decimal FourthGroupSum { get; set; }
    }
}
