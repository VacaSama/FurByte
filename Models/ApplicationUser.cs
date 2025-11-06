using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FurByte.Models;

/// <summary>
/// ApplicationUser models extends Identityuser to 
/// include additional properties needed for the FurByte application.
/// 
/// The ApplicationUser covers Identity management for users and overseers. 
/// </summary>
public class ApplicationUser : IdentityUser
{
	public required string FirstName { get; set; }
	public required string LastName { get; set; }

	/// <summary>
	/// Retrieves and sets the DOB from the user, 
	/// the user must be 13 years or older to register. 
	/// </summary>
	public DateOnly DateOfBirth { get; set; }

	/// <summary>
	/// Each user starts with 500 PetCoins to use in the app.
	/// They can earn more by taking care of their pets. 
	/// </summary>
	public int PetCoins { get; set; } = 500; // starting coin amount for each new user.

	/// <summary>
	/// A rank system to reward users for taking care of their pets.
	/// And or/ to keep track of Overseer levels.
	/// The higher the Overseer level the more permissions they have and 
	/// employees to manage. 
	/// </summary>
	public int Rank { get; set; } = 1; // Default rank

	/// <summary>
	/// Gets or sets the experience points for the user, in order for
	/// them to rank up
	/// </summary>
	public int Experience { get; set; } = 0;

	/// <summary>
	/// Experience points needed to reach the next rank.
	/// Simple formula: 100 * current rank.
	/// </summary>
	public int ExperienceToNextRank => 100 * Rank;

	// Shows the users purchases from the Pet Store(online).
	public ICollection<UserProduct>? Purchases { get; set; }
    public ICollection<Pet>? Pets { get; set; }
    public ICollection<Product>? Products { get; set; }
}
