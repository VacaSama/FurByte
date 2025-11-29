using FurByte.Data;
using FurByte.Models;
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
	public IActionResult LoadStorePartial()
	{
		// edit documentation comments below
		///
		/// 
		/// specifies that the pet name should be included when
		/// retrieving pets from the database
		var pets = _context.Pets.Select(p => new StorePetViewModel
		{
			PetName = p.PetName,
			ImageUrl = p.ImageUrl,
			PetFee = p.PetFee
		}).ToList();

		///
		var products = _context.Products.Select(p => new StoreProductViewModel
		{
			ProductName = p.ProductName,
			Category = p.Category,
			Description = p.Description,
			ImageUrl = p.ImageUrl,
			Price = p.Price
		}).ToList();

		///
		var userProducts = _context.UserProducts.Select(p => new StoreProductViewModel
		{
			QuantityOwned = p.Quantity
		}).ToList();

		///
		var viewModel = new StorePageViewModel
		{
			Pets = pets,
			Products = products
		};
		return PartialView("_StorePartial", viewModel);
	}

}
