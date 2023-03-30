using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using Toto_Simulator.Data;
using Toto_Simulator.Data.Entities;
using Toto_Simulator.Models;

namespace Toto_Simulator.Controllers
{   
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext data;
        public TicketsController(ApplicationDbContext context)
        {
            this.data = context;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AllTickets(string sortOrder, int? pageIndex, int pageSize = 5)
        {
            ViewData["sortOrder"] = sortOrder;
            ViewData["pageSize"] = pageSize;
            ViewData["IdSortParam"] = string.IsNullOrEmpty(sortOrder) ? "desc" : "";

            string currentUserId = GetUserId();
            var tickets = this.data.Tickets.Select(t => new TicketViewModel()
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

            return View(PaginatedList<TicketViewModel>.Create(tickets, pageIndex ?? 1, pageSize));
        }
        // GET: TicketsController
        [HttpGet]
        public IActionResult Index(string sortOrder, int? pageIndex, int pageSize = 5)
        {
            ViewData["sortOrder"] = sortOrder;
            ViewData["pageSize"] = pageSize;
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

            if (tickets.Count() == 0)
            {
                return RedirectToAction("Create");
            }

            tickets = sortOrder switch
            {
                "desc" => tickets.OrderByDescending(j => j.Id),
                _ => tickets.OrderBy(j => j.Id),
            };
           
            return View(PaginatedList<TicketViewModel>.Create(tickets, pageIndex ?? 1, pageSize));
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
                Price = 5,
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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            var ticket = this.data.Tickets.Include(t => t.Numbers).Where(t => t.Id == id).FirstOrDefault();
            if (id == null || this.data.Tickets == null)
            {
                return NotFound();
            }


            if (ticket == null)
            {
                return NotFound();
            }

            TicketFormModel ticketModel = new TicketFormModel() 
            { 
                //Price = ticket.Price,
                First = ticket.Numbers[0].Value,
                Second = ticket.Numbers[1].Value,
                Third = ticket.Numbers[2].Value,
                Fourth = ticket.Numbers[3].Value,
                Fifth = ticket.Numbers[4].Value,
                Sixth = ticket.Numbers[5].Value,
            };

            return View(ticketModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, TicketFormModel ticketModel)
        {
            var ticket = this.data.Tickets.Include(t => t.Numbers).Where(t => t.Id == id).FirstOrDefault();
            if (ticket == null)
            {
                return BadRequest();
            }

            int[] chosenNums =
            {
                ticketModel.First, 
                ticketModel.Second, 
                ticketModel.Third, 
                ticketModel.Fourth, 
                ticketModel.Fifth, 
                ticketModel.Sixth
            };
            
            //ticket.Price = ticketModel.Price;
            

            if (HasDuplicates(chosenNums))
            {
                return RedirectToAction("DuplicateError");
            }

            for (int i = 0; i < chosenNums.Length; i++)
            {
                var curNum = this.data.Numbers.Where(n => n.Value == chosenNums[i]).FirstOrDefault();
                ticket.Numbers[i] = curNum;
            }
                     
            this.data.SaveChanges();
            return RedirectToAction("AllTickets", "Tickets");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            Ticket ticket = data.Tickets.Find(id);
            if (ticket == null)
            {
                return BadRequest();
            }
          
            this.data.Tickets.Remove(ticket);
            this.data.SaveChanges();
            return RedirectToAction("AllTickets", "Tickets");
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
