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
        public IActionResult Index(string idSortOrder, string sumSortOrder)
        {
            ViewData["IdSortParam"] = string.IsNullOrEmpty(idSortOrder) ? "desc" : "";          
            ViewData["SumSortParam"] = string.IsNullOrEmpty(sumSortOrder) ? "desc" : "";
            
            IQueryable<Jackpot> jackpots = from j in this.data.Jackpots select j;

            jackpots = idSortOrder switch
            {
                "desc" => jackpots.OrderByDescending(j => j.Id),
                _ => jackpots.OrderBy(j => j.Id),
            };

            jackpots = sumSortOrder switch
            {
                "desc" => jackpots.OrderByDescending(j => j.AccumulatedSum),
                _ => jackpots.OrderBy(j => j.AccumulatedSum),
            };

            return View(jackpots);
        }       
    }
}
