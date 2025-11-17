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
    public required int Price { get; set; } // cost is in pet coins so they will be solid integers
                                        // Optional: track ownership
    public string? ApplicationUserId { get; set; }
    public ApplicationUser? Buyer { get; set; }
    public string? ImageURL { get; set; } // URL to the product image
}

/// <summary>
/// Represents a product associated with a user, including details such as quantity, purchase date, and related
/// entities.
/// </summary>
/// <remarks>This class models the relationship between a user and a product, capturing information such as the
/// quantity purchased, the date of purchase, and references to the associated user and product entities. It is
/// typically used in scenarios where user-specific product data needs to be tracked or managed.</remarks>
public class UserProduct
{
    [Key]
    public int UserProductId { get; set; }
    public int Quantity { get; set; }

    public string? ApplicationUserId { get; set; }
    public required ApplicationUser User { get; set; }
    public int ProductId { get; set; }
    public Product? Products { get; set; }
    public DateTime PurchaseDate { get; set; }
}
