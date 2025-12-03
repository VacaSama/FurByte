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
		var petStats = new PetStats(); // default Pet Stats from the PetStats model
		return View("Index", petStats); // explicitly load Index.cshtml
	}
}
