using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using Toto_Simulator.Data;
using Toto_Simulator.Data.Entities;
using Toto_Simulator.Models;

namespace Toto_Simulator.Controllers
{
    public class DrawsController : Controller
    {
        private readonly ApplicationDbContext data;

        public DrawsController(ApplicationDbContext context)
        {
            this.data = context;
        }
        
        public IActionResult All()
        {
            var draws = this.data.Draws.Select(d => new DrawViewModel()
            {
                Id = d.Id,
                Date = d.Date,
                Numbers = d.Numbers,
                Fund = d.Fund,
                FirstGroupWinners = d.FirstGroupWinners,
                FirstGroupSum = d.FirstGroupSum,
                SecondGroupWinners = d.SecondGroupWinners,
                SecondGroupSum = d.SecondGroupSum,
                ThirdGroupWinners = d.ThirdGroupWinners,
                ThirdGroupSum = d.ThirdGroupSum,
                FourthGroupWinners = d.FourthGroupWinners,
                FourthGroupSum = d.FourthGroupSum,

            }).ToList().OrderByDescending(d => d.Date);

            return View(draws);
        }

        //public IActionResult SetDrawInterval(int interval)
        //{
        //    interval /= 1000;
        //    Timer timer1 = new Timer(CreateDraw, null, 0, interval);
        //    return RedirectToAction("All", "DrawsController");
        //}

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            var draw = this.data.Draws.Where(d => d.Id == id).FirstOrDefault();
            if (id == null || this.data.Draws == null)
            {
                return NotFound();
            }


            if (draw == null)
            {
                return NotFound();
            }

            DrawFormModel drawModel = new DrawFormModel()
            {
                Fund = draw.Fund,
                FirstGroupWinners = draw.FirstGroupWinners,
                FirstGroupSum = draw.FirstGroupSum,
                SecondGroupWinners = draw.SecondGroupWinners,
                SecondGroupSum = draw.SecondGroupSum,
                ThirdGroupWinners = draw.ThirdGroupWinners,
                ThirdGroupSum = draw.ThirdGroupSum,
                FourthGroupWinners = draw.FourthGroupWinners,
                FourthGroupSum = draw.FourthGroupSum             
            };

            return View(drawModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, DrawFormModel drawModel)
        {
            var draw = this.data.Draws.Where(d => d.Id == id).FirstOrDefault();
            if (draw == null)
            {
                return BadRequest();
            }
            

            draw.Fund = drawModel.Fund;
            draw.FirstGroupWinners = drawModel.FirstGroupWinners;
            draw.FirstGroupSum = drawModel.FirstGroupSum;
            draw.SecondGroupWinners = drawModel.SecondGroupWinners;
            draw.SecondGroupSum = drawModel.SecondGroupSum;
            draw.ThirdGroupWinners = drawModel.ThirdGroupWinners;
            draw.ThirdGroupSum = drawModel.ThirdGroupSum;
            draw.FourthGroupWinners = drawModel.FourthGroupWinners;
            draw.FourthGroupSum = drawModel.FourthGroupSum;
           

            this.data.SaveChanges();
            return RedirectToAction("All", "Draws");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            Draw draw = this.data.Draws.Find(id);
            if (draw == null || draw == this.data.Draws.ToList().OrderByDescending(d => d.Date).FirstOrDefault())
            {
                return BadRequest();
            }

            var drawTickets = this.data.Tickets.Where(t => t.DrawId == draw.Id);
            if (drawTickets.Any())
            {
                foreach (var ticket in drawTickets)
                {
                    this.data.Tickets.Remove(ticket);
                }
            }

            this.data.Draws.Remove(draw);
            this.data.SaveChanges();
            return RedirectToAction("All", "Draws");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateDraw()
        {
            var oldDraw = this.data.Draws.OrderBy(d => d.Date).Last();

            //Make the logic to generate 6 random numbers or Call a method that does it
            //Populate the winning numbers
            GenerateWinningNumbers(oldDraw);
            //Make fund
            decimal fund = 0;
            var currentTickets = this.data.Tickets.Include(t => t.Numbers).Where(t => t.DrawId == oldDraw.Id).ToList();
            foreach (var ticket in currentTickets)
            {
                fund += ticket.Price;
            }
            oldDraw.Fund = fund / 2;

            var oldJackpot = this.data.Jackpots.OrderBy(d => d.Id).Last();
            decimal otherGoupSum = oldDraw.Fund * 20 / 100;
            decimal primaryGroupSum = oldJackpot.AccumulatedSum + oldDraw.Fund * 40 / 100;
            oldDraw.FirstGroupSum = primaryGroupSum;
            oldDraw.SecondGroupSum = otherGoupSum;
            oldDraw.ThirdGroupSum = otherGoupSum;
            oldDraw.FourthGroupSum = otherGoupSum;

            
            //Check every ticket and check the matching numbers
            foreach (var ticket in currentTickets)
            {
                int matches = 0;
                for (int i = 0; i <= 5; i++)
                {
                    for (int j = 0; j <= 5; j++)
                    {
                        if (oldDraw.Numbers[i].Value == ticket.Numbers[j].Value)
                        {                           
                            matches++;
                        }
                    }
                }
                switch (matches)
                {
                    case 3:
                        oldDraw.FourthGroupWinners++;
                        ticket.IsInFourthGroup = true;
                        break;
                    case 4:
                        oldDraw.ThirdGroupWinners++;
                        ticket.IsInThirdGroup = true;
                        break;
                    case 5:
                        oldDraw.SecondGroupWinners++;
                        ticket.IsInSecondGroup = true;
                        break;
                    case 6:
                        oldDraw.FirstGroupWinners++;
                        ticket.IsInFirstGroup = true;
                        break;
                    default:
                        break;
                }
            }
            //Populate the winners and their sums
            var fourthGroup = currentTickets.Where(x => x.IsInFourthGroup);
            decimal fourthGroupSingleSum = fourthGroup.Count() != 0 ? oldDraw.FourthGroupSum / fourthGroup.Count() : 0;
            var thirdGroup = currentTickets.Where(x => x.IsInThirdGroup);
            decimal thirdGroupSingleSum = thirdGroup.Count() != 0 ? oldDraw.ThirdGroupSum / thirdGroup.Count() : 0;
            var secondGroup = currentTickets.Where(x => x.IsInSecondGroup);
            decimal secondGroupSingleSum = secondGroup.Count() != 0 ? oldDraw.SecondGroupSum / secondGroup.Count() : 0;
            var firstGroup = currentTickets.Where(x => x.IsInFirstGroup);
            decimal firstGroupSingleSum = firstGroup.Count() != 0 ? oldDraw.FirstGroupSum / firstGroup.Count() : 0;
            //Give the people their money
            foreach (var ticket in fourthGroup)
            {
                var user = this.data.Users.Where(u => u.Id == ticket.OwnerId).FirstOrDefault();
                user.Earnings += fourthGroupSingleSum;
            }

            foreach (var ticket in thirdGroup)
            {
                var user = this.data.Users.Where(u => u.Id == ticket.OwnerId).FirstOrDefault();
                user.Earnings += thirdGroupSingleSum;
            }

            foreach (var ticket in secondGroup)
            {
                var user = this.data.Users.Where(u => u.Id == ticket.OwnerId).FirstOrDefault();
                user.Earnings += secondGroupSingleSum;
            }

            foreach (var ticket in firstGroup)
            {
                var user = this.data.Users.Where(u => u.Id == ticket.OwnerId).FirstOrDefault();
                user.Earnings += firstGroupSingleSum;
            }

            //Generate Jackpot
            if (oldDraw.FirstGroupWinners == 0)
            {
                Jackpot jackpot = new Jackpot()
                {
                    AccumulatedSum = primaryGroupSum
                };
                this.data.Jackpots.Add(jackpot);
            }
            else
            {
                Jackpot jackpot = new Jackpot()
                {
                    AccumulatedSum = 0
                };
                this.data.Jackpots.Add(jackpot);
            }
            //Create the next draw empty
            Draw draw = new Draw()
            {
                Date = DateTime.Now,

            };
            this.data.Draws.Add(draw);
            this.data.SaveChanges();
            return RedirectToAction("All");
        }
        public void GenerateWinningNumbers(Draw currentDraw)
        {
            Random m_random = new Random();

            int[] selectedNumbers = new int[6];

            // For each array member, assign a random number
            for (int numberCount = 0; numberCount < selectedNumbers.Length; numberCount++)
            {

                int newNumber = m_random.Next(1, 50);

                for (int i = 0; i < numberCount; i++)
                {
                    if (newNumber == selectedNumbers[i])
                    {
                        // MessageBox.Show(“A duplicate (” + newNumber + “) has occured”);
                        newNumber = m_random.Next(1, 50); // Assign a new number
                                                          // MessageBox.Show(“Replacing with ” + newNumber);
                        continue; // Test again
                    }
                }

                selectedNumbers[numberCount] = newNumber;

            }
            Array.Sort(selectedNumbers);

            for (int x = 0; x < selectedNumbers.Length; x++)
            {
                var number = data.Numbers.Where(n => n.Value == selectedNumbers[x]).FirstOrDefault();
                number.Ocurrences++;
                currentDraw.Numbers.Add(number);
            }

            //Test for winnings
            //var num1 = data.Numbers.Where(n => n.Value == 1).FirstOrDefault();
            //var num2 = data.Numbers.Where(n => n.Value == 2).FirstOrDefault();
            //var num3 = data.Numbers.Where(n => n.Value == 3).FirstOrDefault();
            //var num4 = data.Numbers.Where(n => n.Value == 4).FirstOrDefault();
            //var num5 = data.Numbers.Where(n => n.Value == 5).FirstOrDefault();
            //var num6 = data.Numbers.Where(n => n.Value == 6).FirstOrDefault();

                //currentDraw.Numbers.Add(num1);
                //currentDraw.Numbers.Add(num2);
                //currentDraw.Numbers.Add(num3);
                //currentDraw.Numbers.Add(num4);
                //currentDraw.Numbers.Add(num5);
                //currentDraw.Numbers.Add(num6);
        }
    }
}
