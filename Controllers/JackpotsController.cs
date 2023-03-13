using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using Toto_Simulator.Data;
using Toto_Simulator.Data.Entities;
using Toto_Simulator.Models;

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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            var jackpot = this.data.Jackpots.Where(j => j.Id == id).FirstOrDefault();
            if (id == null || this.data.Jackpots == null)
            {
                return NotFound();
            }

            if (jackpot == null)
            {
                return NotFound();
            }
            
            return View(jackpot);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, Jackpot edited)
        {
            var jackpot = this.data.Jackpots.Where(j => j.Id == id).FirstOrDefault();
            if (jackpot == null)
            {
                return BadRequest();
            }

            jackpot.AccumulatedSum = edited.AccumulatedSum;
            
            this.data.SaveChanges();
            return RedirectToAction("Index", "Jackpots");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            Jackpot jackpot = this.data.Jackpots.Find(id);
            if (jackpot == null)
            {
                return BadRequest();
            }
           
            this.data.Jackpots.Remove(jackpot);
            this.data.SaveChanges();
            return RedirectToAction("Index", "Jackpots");
        }
    }
}
