﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Toto_Simulator.Data;
using Toto_Simulator.Data.Entities;
using Toto_Simulator.Models;

namespace Toto_Simulator.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly UserManager<User> userManager;

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly ApplicationDbContext context;

        public AdministrationController(UserManager<User> _userManager, RoleManager<IdentityRole> _roleManager, ApplicationDbContext _context)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Create all roles
        //public async Task<IActionResult> CreateRole()
        //{
        //    await roleManager.CreateAsync(new IdentityRole()
        //    {
        //        Name = "Admin"
        //    });

        //    await roleManager.CreateAsync(new IdentityRole()
        //    {
        //        Name = "Player"
        //    });


        //    return Ok();
        //}

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AllUsers(string searchedName, string sortOrder)
        {
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "desc" : "";

            IQueryable<User> users =  from u in context.Users select u;

            if (!string.IsNullOrEmpty(searchedName))
            {               
                users = users.Where(user =>
                   user.FirstName.Contains(searchedName)
                || user.LastName.Contains(searchedName));
            }

            users = sortOrder switch
            {
                "desc" => users.OrderByDescending(u => u.UserName),
                _ => users.OrderBy(u => u.UserName),
            };

            var displayUsers = users
                .Select(u => new UserListViewModel()
                {
                    Id = u.Id,
                    Username = u.UserName,
                    Name = $"{u.FirstName} {u.LastName}",
                    Email = u.Email,
                    Roles = userManager.GetRolesAsync(u).Result,
                    Earnings = u.Earnings
                })                
                .ToList();


            return View(displayUsers);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || context.Users == null)
            {
                return NotFound();
            }

            var user = context.Users.Where(u => u.Id == id).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string? id, User userModel)
        {
            if (!this.User.IsInRole("Admin"))
            {
                return Unauthorized();
            }

            User user =  context.Users.Find(id);
            if (user == null)
            {
                return BadRequest();
            }


            user.UserName = userModel.UserName;
            user.Earnings = userModel.Earnings;
            user.Email = userModel.Email;

            this.context.SaveChanges();
            return RedirectToAction("AllUsers", "Administration");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MakeAdmin(string id)
        {
            if (id == null || context.Users == null)
            {
                return NotFound();
            }

            var user = context.Users.Where(u => u.Id == id).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                var currentRole = userManager.GetRolesAsync(user).Result.First();
                await userManager.RemoveFromRoleAsync(user, currentRole);
                await userManager.AddToRoleAsync(user, "Admin");
            }
            catch (Exception ex)
            {
                throw;
            }

            return RedirectToAction("AllUsers");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MakePlayer(string id)
        {
            if (id == null || context.Users == null)
            {
                return NotFound();
            }

            var user = context.Users.Where(u => u.Id == id).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                var currentRole = userManager.GetRolesAsync(user).Result.First();
                await userManager.RemoveFromRoleAsync(user, currentRole);
                await userManager.AddToRoleAsync(user, "Player");
            }
            catch (Exception ex)
            {
                throw;
            }

            return RedirectToAction("AllUsers");
        }
    }
}