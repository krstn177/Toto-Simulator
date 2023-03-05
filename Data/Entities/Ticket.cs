using System.ComponentModel.DataAnnotations;

namespace Toto_Simulator.Data.Entities
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        public DateTime Date { get; set; }

        public int DrawId { get; set; }
       
        public Draw Draw { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public User Owner { get; init; }

        public List<Number> Numbers { get; set; } = new List<Number>(6);

        public bool IsInFirstGroup { get; set; }

        public bool IsInSecondGroup { get; set; }

        public bool IsInThirdGroup { get; set; }

        public bool IsInFourthGroup { get; set; }


    }
}
