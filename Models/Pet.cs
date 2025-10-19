using System.ComponentModel.DataAnnotations;

namespace FurByte.Models;

public class Pet
{
    [Key]
    public int PetId { get; set; }
    [Required]
    public required string PetName { get; set; }

    [Required]
    public required string PetType { get; set; } // cat, dog, bird...etc

    public PetStats? Stats { get; set; }  // Navigation property to PetStats
    
    // Foreign key to ApplicationUser
    public string? ApplicationUserId { get; set; }
    public ApplicationUser? Owner { get; set; }
    public string? ImageUrl { get; set; } // URL to the pet image
    
   

}
public class PetStats 
{
    [Key]
    public int PetStatsId { get; set; }
    public string PetMood { get; set; } = "Happy"; // mood of the pet, e.g., "Happy", "Sad", "Hungry", etc.
    public int Happiness { get; set; } = 50; // happiness level of the pet, ranges from 0 to 100
    public int Energy { get; set; } = 75; // energy level of the pet, ranges from 0 to 100
    public int Hunger { get; set; } = 50; // hunger level of the pet, ranges from 0 to 100
    public int Hygiene { get; set; } = 50; // hygiene level of the pet, ranges from 0 to 100

    [Required]
    public DateTime LastUpdated { get; set; } = DateTime.Now; // timestamp of the last update to the pet's status
}

