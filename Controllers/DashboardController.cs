using Microsoft.AspNetCore.Mvc;

namespace FurByte.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
