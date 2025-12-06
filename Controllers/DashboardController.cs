using FurByte.Data;
using FurByte.Models;
using FurByte.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FurByte.Controllers;

    public class DashboardController : Controller
    {

	private readonly ApplicationDbContext _context;

	public DashboardController(ApplicationDbContext context)
	{
		_context = context;
	}
	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	public IActionResult Index()
        {
		var dashboardView = new DashboardViewModel();
		if (dashboardView.PetStats == null)
		{
			throw new Exception("PetStats is null!");
		}
		return View("Index", dashboardView); // explicitly load Index.cshtml
	}
}
