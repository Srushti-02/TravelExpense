using Microsoft.AspNetCore.Mvc;
using TravelExpense.Data;
using TravelExpense.Models;

namespace TravelExpense.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpenseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(
            string EmployeeEmail,
            string Category,
            decimal Amount,
            string Description)
        {
            ExpenseClaim claim = new ExpenseClaim()
            {
                EmployeeId = EmployeeEmail,
                CategoryId = Category,
                Amount = Amount,
                Description = Description,
                Status = "Pending",
                CreatedDate = DateTime.Now
            };

            _context.ExpenseClaims.Add(claim);

            _context.SaveChanges();

            ViewBag.Message = "Expense Claim Submitted Successfully";

            return View();
        }

        public IActionResult MyClaims()
        {
            var claims = _context.ExpenseClaims.ToList();

            return View(claims);
        }
    }
}