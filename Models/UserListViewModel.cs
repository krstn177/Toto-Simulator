namespace Toto_Simulator.Models
{
    public class UserListViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }
       
        public string Email { get; set; }

        public IList<string> Roles { get; set; } = new List<string>();

        public decimal Earnings { get; set; }
    }
}
