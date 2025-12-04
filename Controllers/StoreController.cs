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
		var pets = _context.Pets.Select(p => new StorePetViewModel
		{
			PetName = p.PetName,
			PetType = p.PetType,
			PetFee = p.PetFee,
			PetGender = p.Gender,
			ImageUrl = p.ImageUrl,
			IsAdopted = p.IsAdopted
		}).ToList();

		var products = _context.Products.Select(pr => new StoreProductViewModel
		{
			ProductName = pr.ProductName,
			Category = pr.Category,
			Description = pr.Description,
			Price = pr.Price,
			ImageUrl = pr.ImageUrl
		}).ToList();

		var viewModel = new StorePageViewModel
		{
			Pets = pets,
			Products = products
		};

		return PartialView(viewModel);
	}
}
