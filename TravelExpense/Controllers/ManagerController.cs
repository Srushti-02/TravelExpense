using Microsoft.AspNetCore.Mvc;
using TravelExpense.Data;

namespace TravelExpense.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult PendingClaims()
        {
            var claims = _context.ExpenseClaims
                                 .Where(x => x.Status == "Pending")
                                 .ToList();

            return View(claims);
        }

        public IActionResult Approve(int id)
        {
            var claim = _context.ExpenseClaims
                                .FirstOrDefault(x => x.ClaimId == id);

            if (claim != null)
            {
                claim.Status = "Approved";

                _context.SaveChanges();
            }

            return RedirectToAction("PendingClaims");
        }

        public IActionResult Reject(int id)
        {
            var claim = _context.ExpenseClaims
                                .FirstOrDefault(x => x.ClaimId == id);

            if (claim != null)
            {
                claim.Status = "Rejected";

                _context.SaveChanges();
            }

            return RedirectToAction("PendingClaims");
        }
    }
}