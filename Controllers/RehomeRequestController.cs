using Microsoft.AspNetCore.Mvc;
using FurByte.Data;
using FurByte.Models;

namespace FurByte.Controllers;

public class RehomeRequestController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
