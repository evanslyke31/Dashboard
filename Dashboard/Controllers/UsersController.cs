using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Data;
using Dashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace Dashboard.Controllers
{
    public class UsersController : Controller
    {

        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id","Username","Password")] User user)
        {
            if (user.Username == null || user.Password == null)
            {
                return View("Index");
            }
            var account = await _context.User
                .FirstOrDefaultAsync(m => m.Username == user.Username);
            if(account != null)
            {
                ViewData["message"] = "User already exists";
                return View("Index");
            }
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["message"] = "User created successfully";
            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Authorize(Dashboard.Models.User user)
        {
            if (user.Username == null || user.Password == null)
            {
                return View("Index");
            }

            var account = await _context.User
                .FirstOrDefaultAsync(m => m.Username == user.Username && m.Password == user.Password);
            if (account == null)
            {
                ViewData["message"] = "username or password not found";
                return View("Index");
            }

            user.Password = "";
            return View("Panel", user);
        }

    }
}