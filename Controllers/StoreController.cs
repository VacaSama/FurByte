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
}
