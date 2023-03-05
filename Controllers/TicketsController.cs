using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Index()
        {
            string currentUserId = GetUserId();
            var tickets = this.data.Tickets.Where(t => t.OwnerId == currentUserId).Select(t => new TicketViewModel()
            {
                Id = t.Id,
                Date = t.Date,
                Price = t.Price,
                DrawId = t.DrawId,
                Owner = t.Owner,
                Numbers = t.Numbers
                
            }).ToList().OrderByDescending(t => t.Date);


            return View(tickets);          
        }

        // GET: TicketsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TicketsController/Create
        public ActionResult Create()
        {
            var numbersValues = this.data.Numbers.Select(n => n.Value);
            TicketFormModel ticketModel = new TicketFormModel();
            return View(ticketModel);
        }

        // POST: TicketsController/Create
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
                OwnerId = currentUserId
            };
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
        private string GetUserId() => this.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
