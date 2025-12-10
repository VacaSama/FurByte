using Microsoft.AspNetCore.Mvc;
using FurByte.Data;
using FurByte.Models;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace FurByte.Controllers;

public class RehomeRequestController : Controller
{
	private readonly ApplicationDbContext _context;

	public RehomeRequestController(ApplicationDbContext context)
	{
		_context = context;
	}
	[HttpGet]
	public IActionResult Index()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Index(RehomeRequest request)
	{
		if (ModelState.IsValid)
		{
			request.Status = RehomeStatus.Pending; // default status
			_context.RehomeRequests.Add(request);
			await _context.SaveChangesAsync();

			// redirect after save
			return RedirectToAction("Success");
		}

		// if validation fails, reload form
		return View(request);
	}

	public IActionResult Success()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Approve(int id)
	{
		var request = await _context.RehomeRequests.FindAsync(id);
		if (request == null) return NotFound();

		request.Status = RehomeStatus.Approved;
		await _context.SaveChangesAsync();

		return RedirectToPage("/Overseer/OverseerDashboard");
	}

	[HttpPost]
	public async Task<IActionResult> Deny(int id)
	{
		var request = await _context.RehomeRequests.FindAsync(id);
		if (request == null) return NotFound();

		request.Status = RehomeStatus.Rejected; // or delete if you want
		await _context.SaveChangesAsync();

		return RedirectToPage("/Overseer/OverseerDashboard");
	}

}
