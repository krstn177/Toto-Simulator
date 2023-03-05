using Toto_Simulator.Data.Entities;

namespace Toto_Simulator.Models
{
    public class DrawViewModel
    {
        public int Id { get; init; }

        public DateTime Date { get; set; }

        public List<Number> Numbers { get; set; } = new List<Number>(6);

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
