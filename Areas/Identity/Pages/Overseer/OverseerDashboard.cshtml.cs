using FurByte.Data;
using FurByte.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Providers;
using System.ComponentModel.DataAnnotations;

namespace FurByte.Areas.Identity.Pages.Overseer;

[Authorize(Roles = "Overseer")]
public class OverseerDashboardModel : PageModel
{
	/// <summary>
	/// A readonly field to hold the ApplicationDbContext instance, 
	/// named _context so that we can access/reference the database
	/// </summary>
	private readonly ApplicationDbContext _context;

	/// <summary>
	/// Retrieves the user data from ApplicationUser model.
	/// keep it private to avoid exposing sensitive data.
	/// </summary>
	private readonly UserManager<ApplicationUser> _userManager;

	public OverseerDashboardModel(UserManager<ApplicationUser> userManager, ApplicationDbContext context) {
		_userManager = userManager;
		_context = context; 
	}

	// Properties for managing overseer information
	[Required]
	public required string OverseerFirstName { get; set; }

	[Required]
	public required string OverseerLastName { get; set; }

	[Required]
	[EmailAddress]
	public required string OverseerEmail { get; set; }

	[Required]
	public int OverseerRank { get; set; } = 1; // default and lowest rank



	/*AUTHORIZATION - OnGetAsync() method is testing to see if there is a user 
	 * and checking to see if the user is an overseer. 
	 * IF the user is null and the user is not an Overseer than they are not allowed
	 * to see the Overseer Dashboard :) 
	 */
	public async Task<IActionResult> OnGetAsync()
	{
		var user = await _userManager.GetUserAsync(User);
		if (user == null || !await _userManager.IsInRoleAsync(user, "Overseer"))
		{
			return Forbid();
		}

		OverseerFirstName = user.FirstName;
		OverseerLastName = user.LastName;
		OverseerEmail = user.Email;
		OverseerRank = user.Rank;

		return Page();
	}

	// made async for consistency
	public async Task<IActionResult> OnPostApproveRehomeRequest(int rehomeRequestId)
	{
		// insert logic on how to approve rehome requests
		var rehomeRequest = _context.RehomeRequests.Find(rehomeRequestId);
		// if the rehome request is blank or if the rehome status is NOT pending 
		if(rehomeRequest == null || rehomeRequest.Status != RehomeStatus.Pending)
		{
			// return that it is not found/doesn't exist
			return NotFound();
		}
		// declared a variable that finds and holds the pet that needs to be rehomed 
		// using the petid and current owner/user
		var rehomePet = _context.Pets.FirstOrDefault(p => p.PetName == rehomeRequest.PetName
				&& p.ApplicationUserId == rehomeRequest.OwnerId);

		if (rehomePet == null)
		{
			return BadRequest($"Could not find {rehomeRequest.PetName}, associated with " +
				$"this user"); 
		}

		// reset the current owner now to the NEW Owner
		// (from Jimmy(former owner) => Sally(new owner))
		rehomePet.ApplicationUserId = rehomeRequest.NewOwnerId;

		// set the status to approved or denied. 
		rehomeRequest.Status = RehomeStatus.Approved;
		await _context.SaveChangesAsync();
		// what happens if they are denied?

		// stay on the same page
		return RedirectToPage();
	}
}
