using Microsoft.Identity.Client;
using FurByte.Models;

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
	public List<PetStats>? PetStats { get; set; }
	/// <summary>
	/// 
	/// </summary>
	public List<Pet>? Pets { get; set; }

	public List<Product>? Products { get; set; }

	// Single-item convenience properties
	public Pet? Pet
	{
		// Get the first pet from the list, or null if the list is null or empty
		get => Pets?.FirstOrDefault();
		// Set the Pets list to a new list containing the provided pet,
		// or null if the provided pet is null
		set => Pets = value is null ? null : new List<Pet> { value };
	}

	public PetStats? Stats
	{	
		// Get the first PetStats from the list, or null if the list is null or empty
		get => PetStats?.FirstOrDefault();
		// Set the PetStats list to a new list containing the provided pet,
		// or null if the provided pet is null
		set => PetStats = value is null ? null : new List<PetStats> { value };
	}

}
