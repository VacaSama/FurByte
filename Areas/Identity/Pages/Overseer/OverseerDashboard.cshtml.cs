using FurByte.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FurByte.Areas.Identity.Pages.Overseer;

[Authorize(Roles = "Overseer")]
public class OverseerDashboardModel : PageModel
{
	// retrieve the user data from ApplicationUser model.
	// keep it private to avoid exposing sensitive data.
	private readonly UserManager<ApplicationUser> _userManager;

	public OverseerDashboardModel(UserManager<ApplicationUser> userManager) {
		_userManager = userManager;
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
	public void OnGet()
    {
    }
}
