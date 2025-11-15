namespace FurByte.ViewModels;

/// <summary>
/// Represents the view model for storing a pet in the Pet Store, users 
/// can then view and purchase available pets to then add to their collection/ care
/// </summary>
public class StorePetViewModel
{
	// pet names will be randomly generated
	// Rudy, Bud, Flower example names 
	public string? PetName { get; set; }
	public string? PetType { get; set; } // e.g., "Cat", "Dog", "Dragon"

	// how much the pet costs in pet coins
	// default for now will be 150 pet coins, 
	// I don't want to overprice pets yet
	public int PetFee { get; set; }

	public string? ImageUrl { get; set; }

	// is the pet adopted or not, i want to limit how many times you can 
	// adopt that same pet type. example: yellow cat can only be adopted once
	// by that user. (cooldown period?)
	public bool IsAdopted { get; set; }


}
