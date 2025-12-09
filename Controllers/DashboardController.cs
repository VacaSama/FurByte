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
		var pet = _context.Pets
			.Include(p => p.Stats)
			.FirstOrDefault();

		if (pet == null)
		{
			throw new Exception("No pet found in database.");
		}

		if (pet.Stats == null)
		{
			throw new Exception("PetStats is null in DB.");
		}

		var dashboardView = new DashboardViewModel
		{
			Pets = new List<Pet> { pet },
			PetStats = new List<PetStats> { pet.Stats }
		};

		return View(dashboardView);
	}
}
