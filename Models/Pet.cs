using System.ComponentModel.DataAnnotations;

namespace FurByte.Models;

public class Pet
{
    [Key]
    public int PetId { get; set; }
    [Required]
    public required string PetName { get; set; }
    [Required]
    public required string Species { get; set; } // focusing on cats right now but could expand to dogs, birds, etc.
    [Required]  
    public required string Breed { get; set; }

    // Foreign key to the User who owns the pet
    public int UserId { get; set; }

    // Foreign key to ApplicationUser
    public string? ApplicationUserId { get; set; }
    public ApplicationUser? Owner { get; set; }
    public string? ImageUrl { get; set; } // URL to the pet image
    
    [Required]
    public DateTime LastUpdated { get; set; } = DateTime.Now; // timestamp of the last update to the pet's status

}
