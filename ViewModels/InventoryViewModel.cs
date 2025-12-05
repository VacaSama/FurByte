using FurByte.Models;

namespace FurByte.ViewModels;


/// <summary>
/// The Inventory View Model, represents the users inventory so that they can 
/// keep track of products that they have and keep up with how many pet coins they have. 
/// </summary>
public class InventoryViewModel
{
	public Product Product { get; set; }
	/// <summary>
	/// The product Quantity that they have remaining
	/// </summary>
	public int Quantity { get; set; }
	/// <summary>
	/// The name of the Product Item 
	/// </summary>
	public required string ProductName { get; set; }
	/// <summary>
	/// The product category type // e.g., "Pet", "Food", "Toy"
	/// </summary>
	public required string Category { get; set; } 

	/// <summary>
	/// Description of the product in the users inventory. 
	/// </summary>
	public required string Description { get; set; }

	/// <summary>
	/// Product Image that will be shown when the application loads
	/// </summary>
	public string? ImageUrl { get; set; } // URL to the product image

	/// <summary>
	/// Each user starts with 500 PetCoins to use in the app.
	/// They can earn more by taking care of their pets. 
	/// </summary>
	public int PetCoins { get; set; } = 500; // starting coin amount for each new user.

}
