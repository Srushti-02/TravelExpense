using Microsoft.AspNetCore.Mvc;

namespace TravelExpense.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}