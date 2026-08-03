using Microsoft.AspNetCore.Mvc;
using TravelExpense.Data;

namespace TravelExpense.Controllers
{
    public class FinanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FinanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult ApprovedClaims()
        {
            var claims = _context.ExpenseClaims
                                 .Where(x => x.Status == "Approved")
                                 .ToList();

            return View(claims);
        }

        public IActionResult MarkPaid(int id)
        {
            var claim = _context.ExpenseClaims
                                .FirstOrDefault(x => x.ClaimId == id);

            if (claim != null)
            {
                claim.Status = "Paid";

                _context.SaveChanges();
            }

            return RedirectToAction("ApprovedClaims");
        }
    }
}