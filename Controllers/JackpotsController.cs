using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Toto_Simulator.Data;
using Toto_Simulator.Data.Entities;

namespace Toto_Simulator.Controllers
{
    public class JackpotsController : Controller
    {
        private readonly ApplicationDbContext data;

        public JackpotsController(ApplicationDbContext context)
        {
            this.data = context;
        }
        public IActionResult Index(string sortOrder)
        {
            ViewData["IdSortParam"] = string.IsNullOrEmpty(sortOrder) ? "id_desc" : "";          
            ViewData["SumSortParam"] = sortOrder == "Sum" ? "sum_desc" : "Sum";
            
            IQueryable<Jackpot> jackpots = from j in this.data.Jackpots select j;

            switch (sortOrder)
            {
                case "id_desc":
                    jackpots = jackpots.OrderByDescending(s => s.Id);
                    break;
                case "Sum":
                    jackpots = jackpots.OrderBy(s => s.AccumulatedSum);
                    break;
                case "sum_desc":
                    jackpots = jackpots.OrderByDescending(s => s.AccumulatedSum);
                    break;
                default:
                    jackpots = jackpots.OrderBy(s => s.Id);
                    break;
            }

            return View(jackpots);
        }       
    }
}
