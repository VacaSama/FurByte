using FurByte.Data;
using FurByte.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FurByte.Controllers;

public class StoreController : Controller
{
	/// <summary>
	/// A readonly field to hold the ApplicationDbContext instance, 
	/// named _context so that we can access/reference the database
	/// </summary>
	private readonly ApplicationDbContext _context;

	/// <summary>
	/// We need to inject the ApplicationDbContext, and retrieve data 
	/// from the database 
	/// </summary>
	/// <param name="context"></param>
	public StoreController(ApplicationDbContext context)
	{
		_context = context;
	}

	public IActionResult Index()
	{
		return View();
	}

	/// <summary>
	/// this IActionResult method returns a partial view for the store page
	/// a pop-up window that displays out store items without reloading the entire page
	/// </summary>
	/// <returns></returns>
	public IActionResult Partial()
	{
		// specifies that the pet name should be included when
		// retrieving pets from the database
		var pets = _context.Pets.Include(p => p.PetName).ToList();
		var viewModel = new StorePageViewModel();
		return PartialView("_StorePartial", viewModel);
	}
}
