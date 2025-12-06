using FurByte.Models;
using Microsoft.Identity.Client;

namespace FurByte.ViewModels;

public class DashboardViewModel
{
	public InventoryViewModel? Inventory { get; set; }

	public List<StoreProductViewModel>? StoreProducts { get; set; }
	public List<StorePetViewModel>? StorePets { get; set; }

	/// <summary>
	/// PetStats class give value to the various progress bars for the pets
	/// needs/wants and mood. Over a period of time these stats 
	/// will decay.
	/// </summary>
	public PetStats? PetStats { get; set; }
}
