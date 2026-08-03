using Microsoft.AspNetCore.Mvc;

namespace TravelExpense.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}