using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dashboard.Data;
using Dashboard.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Newtonsoft.Json;

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
            if(HttpContext.Session.GetString("user") != null)
            {
                HttpContext.Session.Clear();
                HttpContext.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
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
            HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));

            var accountClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, account.Username)
            };

            var userIdentity = new ClaimsIdentity(accountClaims, "User Identity");

            var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });

            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index", "Home");
        }

    }
}