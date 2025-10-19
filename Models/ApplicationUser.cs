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
    public DateTime DateOfBirth { get; set; }
    public int PetCoins { get; set; }

    public ICollection<Pet>? Pets { get; set; }

    public ICollection<Product>? Products { get; set; }
}
