using Microsoft.AspNetCore.Mvc;
using TravelExpense.Data;
using TravelExpense.Models;
using TravelExpense.ViewModels;

namespace TravelExpense.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // REGISTER

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(
            string Name,
            string Email,
            string Password,
            string Role)
        {
            User user = new User()
            {
                Name = Name,
                Email = Email,
                PasswordHash = Password,
                Role = Role
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            ViewBag.Message = "User Registered Successfully";

            return View();
        }

        // LOGIN

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(
            string Email,
            string Password)
        {
            var user = _context.Users
                .FirstOrDefault(x =>
                    x.Email == Email &&
                    x.PasswordHash == Password);

            if (user == null)
            {
                ViewBag.Message = "Invalid Credentials";
                return View();
            }

            if (user.Role == "Admin")
                return RedirectToAction("Dashboard", "Admin");

            if (user.Role == "Manager")
                return RedirectToAction("Dashboard", "Manager");

            if (user.Role == "Finance")
                return RedirectToAction("Dashboard", "Finance");

            return RedirectToAction("Dashboard", "Employee");
        }
    }
}