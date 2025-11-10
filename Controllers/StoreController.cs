using Microsoft.AspNetCore.Mvc;

namespace FurByte.Controllers;

public class StoreController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
