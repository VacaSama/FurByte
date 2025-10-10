using System.ComponentModel.DataAnnotations;

namespace FurByte.Models
{
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

        // Navigation property to the User
        public User? User { get; set; }

        public string PetMood { get; set; } = "Happy"; // mood of the pet, e.g., "Happy", "Sad", "Hungry", etc.
        public int Happiness { get; set; } = 50; // happiness level of the pet, ranges from 0 to 100
        public int Hunger { get; set; } = 50; // hunger level of the pet, ranges from 0 to 100
        public int Hygiene { get; set; } = 50; // hygiene level of the pet, ranges from 0 to 100
        public string? ImageUrl { get; set; } // URL to the pet image
        
        [Required]
        public DateTime LastUpdated { get; set; } = DateTime.Now; // timestamp of the last update to the pet's status

    }
}
