using FurByte.Data;
using FurByte.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FurByte.Controllers
{
    public class DashboardController : Controller
    {
		private readonly ApplicationDbContext _context;
		public DashboardController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
        {
            return View();
        }

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
}
