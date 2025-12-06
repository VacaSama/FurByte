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
    [Key]
    public int PetId { get; set; }
    [Required]
    public required string PetName { get; set; }

    [Required]
    public required string PetType { get; set; } // cat, dog, bird...etc

	public int PetFee { get; set; } = 150; // cost of the pet in pet coins

	[Required] // the pets gender use enum to cycle through?
	public required PetGender Gender { get; set; }

	public PetStats? Stats { get; set; }  // Navigation property to PetStats
    
    // Foreign key to ApplicationUser
    public string? ApplicationUserId { get; set; }
    public ApplicationUser? Owner { get; set; }
	public bool IsAdopted { get; set; }
	public string? ImageUrl { get; set; } // URL to the pet image
    
}

/// <summary>
/// PetStats class give value to the various progress bars for the pets
/// needs/wants and mood. Over a period of time these stats 
/// will decay.
/// </summary>
public class PetStats 
{
    [Key]
    public int PetStatsId { get; set; }


	[Required] // 
	public required int PetId { get; set; } // Foreign key to Pet

	[ForeignKey("PetId")]
	public required Pet Pet { get; set; }


	public int UserPet { get; set; } // Foreign key to Pet
	public PetMood PetMood { get; set; } = PetMood.Happy; // mood of the pet, e.g., "Happy", "Sad", "Hungry", etc.
    public int Happiness { get; set; } = 50; // happiness level of the pet, ranges from 0 to 100
    public int Energy { get; set; } = 75; // energy level of the pet, ranges from 0 to 100
    public int Hunger { get; set; } = 50; // hunger level of the pet, ranges from 0 to 100
    public int Hygiene { get; set; } = 50; // hygiene level of the pet, ranges from 0 to 100

    [Required]
    public DateTime LastUpdated { get; set; } = DateTime.Now; // timestamp of the last update to the pet's status
}

