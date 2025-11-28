using FurByte.Models;

namespace FurByte.ViewModels;

/// <summary>
/// This view model stores Store PAGE information, for the UI.
/// It combines both the StorePetViewModel and StoreProductViewModel
/// </summary>
public class StorePageViewModel
{
	/// <summary>
	/// displays available pets in the store
	/// </summary>
	public List<StorePetViewModel>? Pets { get; set; }
	/// <summary>
	/// displays available products in the store
	/// </summary>
	public List<StoreProductViewModel>? Products { get; set; }

	//public List<PetStats>? PetStats { get; set; }
}
