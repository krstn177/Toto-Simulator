
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Toto_Simulator.Data.Entities
{
    public class Draw
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public List<Number> Numbers { get; set; } = new List<Number>(6);

        public List<Ticket> Tickets { get; set; }
        public decimal Fund { get; set; }

        public int FirstGroupWinners { get; set; }
        public decimal FirstGroupSum { get; set; }

        public int SecondGroupWinners { get; set; }
        public decimal SecondGroupSum { get; set; }

        public int ThirdGroupWinners { get; set; }
        public decimal ThirdGroupSum { get; set; }

        public int FourthGroupWinners { get; set; }
        public decimal FourthGroupSum { get; set; }
    }
}
