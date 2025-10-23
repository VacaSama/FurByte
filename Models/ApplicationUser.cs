using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FurByte.Models;

/// <summary>
/// ApplicationUser models extends Identityuser to 
/// include additional properties needed for the FurByte application.
/// </summary>
public class ApplicationUser : IdentityUser
{
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
    
    // Shows the users purchases from the Pet Store(online).
    public ICollection<UserProduct>? Purchases { get; set; }
    public ICollection<Pet>? Pets { get; set; }

    public ICollection<Product>? Products { get; set; }
}
