using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using Toto_Simulator.Data;
using Toto_Simulator.Data.Entities;
using Toto_Simulator.Models;

namespace Toto_Simulator.Controllers
{
    [Authorize(Roles = "Player")]
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext data;
        public TicketsController(ApplicationDbContext context)
        {
            this.data = context;
        }
        // GET: TicketsController
        public ActionResult Index(string sortOrder)
        {
            ViewData["IdSortParam"] = string.IsNullOrEmpty(sortOrder) ? "desc" : "";

            string currentUserId = GetUserId();
            var tickets = this.data.Tickets.Where(t => t.OwnerId == currentUserId).Select(t => new TicketViewModel()
            {
                Id = t.Id,
                Date = t.Date,
                Price = t.Price,
                DrawId = t.DrawId,
                Owner = t.Owner,
                Numbers = t.Numbers
                
            });

            tickets = sortOrder switch
            {
                "desc" => tickets.OrderByDescending(j => j.Id),
                _ => tickets.OrderBy(j => j.Id),
            };

            return View(tickets.ToList());          
        }

        // GET: TicketsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
       
        public ActionResult Create()
        {
            var numbersValues = this.data.Numbers.Select(n => n.Value);
            TicketFormModel ticketModel = new TicketFormModel();
            return View(ticketModel);
        }
       
        [HttpPost]        
        public ActionResult Create(TicketFormModel ticketModel)
        {
            string currentUserId = GetUserId();           
            var currentDraw = this.data.Draws.OrderBy(d => d.Date).Last();


            int[] chosenNums =
            {
                ticketModel.First, 
                ticketModel.Second, 
                ticketModel.Third, 
                ticketModel.Fourth, 
                ticketModel.Fifth, 
                ticketModel.Sixth
            };   
            
            Ticket ticket = new Ticket()
            {
                Price = ticketModel.Price,
                DrawId = currentDraw.Id,
                Date = DateTime.Now,                
                OwnerId = currentUserId,                
            };

            if (HasDuplicates(chosenNums))
            {
                return RedirectToAction("DuplicateError");
            }

            foreach (int num in chosenNums)
            {
                var curNum = this.data.Numbers.Where(n => n.Value == num).FirstOrDefault();
                ticket.Numbers.Add(curNum);
            }
            this.data.Tickets.Add(ticket);
            currentDraw.Tickets.Add(ticket);            
            this.data.SaveChanges();
           
            return RedirectToAction("Index", "Tickets");
        }
        public IActionResult DuplicateError()
        {
            return View();
        }
        private string GetUserId() => this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        public bool HasDuplicates(int[] numsArr)
        {
            foreach (int num1 in numsArr)
            {
                int matches = 0;
                foreach (int num2 in numsArr)
                {
                    if (num1 == num2)
                    {
                        matches++;
                    }
                }
                if (matches > 1)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
