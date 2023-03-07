using Microsoft.AspNetCore.Mvc;
using Toto_Simulator.Data;

namespace Toto_Simulator.Controllers
{
    public class NumbersController : Controller
    {
        private readonly ApplicationDbContext data;

        public NumbersController(ApplicationDbContext context) 
        { 
            this.data = context;
        }
        public IActionResult All()
        {
            var numbers = this.data.Numbers;

            return View(numbers);
        }

        public IActionResult Index(int searchedNum)
        {
            var number = this.data.Numbers.Find(searchedNum);
                        
            return View(number);
        }
    }
}
