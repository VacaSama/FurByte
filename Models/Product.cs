using System.ComponentModel.DataAnnotations;

namespace FurByte.Models;

/// <summary>
/// The Product model represents a store entity that sells pets, pet food, 
/// and toys to the user for various pets. It serves as a central hub for 
/// users to browse and purchase items for their pets.
/// </summary>
public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    public required string ProductName { get; set; }
    public string? Description { get; set; } 
    [Required]
    public required string Category { get; set; } // e.g., "Pet", "Food", "Toy"
    [Required]
    public required int Cost { get; set; } // cost is in pet coins so they will be solid integers
                                           // Optional: track ownership
    public string? ApplicationUserId { get; set; }
    public ApplicationUser? Buyer { get; set; }

    public string? ImageUrl { get; set; } // URL to the product image
}
