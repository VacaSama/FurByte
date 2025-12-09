using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FurByte.ViewModels;
namespace FurByte.Models;

/// <summary>
/// custom enum/data type for pet gender,
/// </summary>
public enum PetGender
{
	Male, 
	Female
}
/// <summary>
/// custom enum/data type for pet mood, 
/// can cycle through: Happy, Sad, Hungry, Tired, Playful.
/// </summary>
public enum PetMood
{
	Happy, 
	Sad, 
	Hungry, 
	Tired, 
	Playful
}

/// <summary>
/// The Pet class represents a virtual Pet that the users can adopt
/// and care for. 
/// </summary>
public class Pet
{
    [Key] /// primary key to the Pet Table
    public int PetId { get; set; }
    [Required] /// whatever the user names their pet will go here *** Add feature to rename.
    public required string PetName { get; set; }

    [Required] /// the type of pet, e.g., "cat", "dog", "bird", etc.
	public required string PetType { get; set; } 

	/// <summary>
	/// Represents the adoption fee for the pet in pet coins.
	/// Some pets may have higher fees based on rarity or special attributes.
	/// </summary>
	public int PetFee { get; set; } = 150; // cost of the pet in pet coins

	[Required] // the pets gender use enum to cycle through?
	public required PetGender Gender { get; set; }

	public PetStats? Stats { get; set; }  // Navigation property to PetStats
    
    // Foreign key to ApplicationUser
    public string? ApplicationUserId { get; set; }
	/// <summary>
	/// The current owner of the pet
	/// </summary>
	public ApplicationUser? Owner { get; set; }
	/// <summary>
	/// Shows if the pet has been adopted or not in the Pet Store. 
	/// </summary>
	public bool IsAdopted { get; set; }
	/// <summary>
	/// Pet Avatar/Img URL 
	/// </summary>
	public string? ImageUrl { get; set; } // URL to the pet image
    
}

/// <summary>
/// PetStats class give value to the various progress bars for the pets
/// needs/wants and mood. Over a period of time these stats 
/// will decay.
/// </summary>
public class PetStats 
{
    [Key] /// Primary Key to the PetStats Table
	public int PetStatsId { get; set; }


	[Required] /// Foreign key to the Pet Class/Model
	[ForeignKey("PetId")]
	public int PetId { get; set; } // Foreign key to Pet Table above ^^ 

	/// <summary>
	/// This is the Pet Object , represents the associated pet for these stats.
	/// </summary>
	public Pet Pet { get; set; }

	/// <summary>
	/// Represents the curent mood of the pet, 
	/// if the values fall within certain ranges the pet's mood will change.
	/// mood of the pet, e.g., "Happy", "Sad", "Hungry", etc.
	/// </summary>
	public PetMood PetMood { get; set; } = PetMood.Happy; // mood of the pet, e.g., "Happy", "Sad", "Hungry", etc.
	/// <summary>
	/// Represents Pet Happiness level from 0 to 100
	/// </summary>
	public int Happiness { get; set; } = 50; // happiness level of the pet, ranges from 0 to 100
	/// <summary>
	/// Represents Pet Energy level from 0 to 100
	/// </summary>
	public int Energy { get; set; } = 75; // energy level of the pet, ranges from 0 to 100
	/// <summary>
	/// Represents Pet Hunger level from 0 to 100
	/// </summary>
	public int Hunger { get; set; } = 50; // hunger level of the pet, ranges from 0 to 100
	/// <summary>
	/// Represents Pet Hygiene level from 0 to 100
	/// </summary>
	public int Hygiene { get; set; } = 50; // hygiene level of the pet, ranges from 0 to 100

    /// <summary>
	/// Represents the last time the pet's stats were updated. 
	/// </summary>
    public DateTime LastUpdated { get; set; } // timestamp of the last update to the pet's status
}

