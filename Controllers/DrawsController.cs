﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Configuration;
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
        public IActionResult Index()
        {
            return View();
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

        public IActionResult CreateDraw()
        {
            var oldDraw = this.data.Draws.OrderBy(d => d.Date).Last();

            //Make the logic to generate 6 random numbers or Call a method that does it
            //Populate the winning numbers
            GenerateWinningNumbers(oldDraw);
            //Make fund
            decimal fund = 0;
            var currentTickets = this.data.Tickets.Include(t => t.Numbers).Where(t => t.DrawId == oldDraw.Id);
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
                            var num = this.data.Numbers.Where(x => x.Value == ticket.Numbers[j].Value).FirstOrDefault();
                            num.Ocurrences++;
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
            var fourthGroup = this.data.Tickets.Where(x => x.IsInFourthGroup == true);
            decimal fourthGroupSingleSum = fourthGroup.Count() != 0 ? oldDraw.FourthGroupSum / fourthGroup.Count() : 0;
            var thirdGroup = this.data.Tickets.Where(x => x.IsInThirdGroup == true);
            decimal thirdGroupSingleSum = thirdGroup.Count() != 0 ? oldDraw.ThirdGroupSum / thirdGroup.Count() : 0;
            var secondGroup = this.data.Tickets.Where(x => x.IsInSecondGroup == true);
            decimal secondGroupSingleSum = secondGroup.Count() != 0 ? oldDraw.SecondGroupSum / secondGroup.Count() : 0;
            var firstGroup = this.data.Tickets.Where(x => x.IsInFirstGroup == true);
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
                currentDraw.Numbers.Add(number);
            }

        }
    }
}