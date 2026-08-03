using Microsoft.AspNetCore.Mvc;
using TravelExpense.Data;
using TravelExpense.ViewModels;

namespace TravelExpense.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            AdminDashboardViewModel model =
                new AdminDashboardViewModel();

            model.TotalUsers =
                _context.Users.Count();

            model.TotalClaims =
                _context.ExpenseClaims.Count();

            model.PendingClaims =
                _context.ExpenseClaims
                        .Count(x => x.Status == "Pending");

            model.ApprovedClaims =
                _context.ExpenseClaims
                        .Count(x => x.Status == "Approved");

            model.PaidClaims =
                _context.ExpenseClaims
                        .Count(x => x.Status == "Paid");

            return View(model);
        }
    }
}