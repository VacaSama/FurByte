namespace FurByte.ViewModels;

/// <summary>
/// This view model stores Store PRODUCT information, for the UI 
/// base. The user can then purchase items for their pets to improve 
/// relations between User=>Digital Pet.
/// </summary>
public class StoreProductViewModel
{ // ONLY the necessary fields for the UI display/purchase
  // of products in the store.
	public string? ProductName { get; set; } 
	public string? Description { get; set; } 
	public string? Category { get; set; } // e.g., "Pet", "Food", "Toy"
	// cost is in pet coins so they will be solid integers
	public int Price { get; set; }
	public string? ImageUrl { get; set; } // URL to the product image

	// Ownership info
	public int QuantityOwned { get; set; }

}
