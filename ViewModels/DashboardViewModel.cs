using FurByte.Models;

namespace FurByte.ViewModels;

public class DashboardViewModel
{
	/// <summary>
	/// Store Page property that retrieves everything I would need for the 
	/// Store modal appear. 
	/// <see cref="StorePageViewModel"/>
	/// </summary>
	public List<StorePageViewModel>? StorePage { get; set; }

	public InventoryViewModel? Inventory { get; set; }

	public  PetStats? PetStats { get; set; }
}
