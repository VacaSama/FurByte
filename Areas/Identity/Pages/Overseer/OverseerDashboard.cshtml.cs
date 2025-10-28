using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FurByte.Areas.Identity.Pages.Overseer;

[Authorize(Roles = "Overseer")]
public class OverseerDashboardModel : PageModel
{
	// Properties for managing overseer information
	[Required]
	public required string OverseerFirstName { get; set; }

	[Required]
	public required string OverseerLastName { get; set; }

	[Required]
	[EmailAddress]
	public required string OverseerEmail { get; set; }

	public int OverseerRank { get; set; } = 1; // default and lowest rank
	
	public void OnGet()
    {
    }
}
