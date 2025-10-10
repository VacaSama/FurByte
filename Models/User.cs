using System.ComponentModel.DataAnnotations;

namespace FurByte.Models
{
    public class User
    {
        [Key] // Primary key
        public int UserId { get; set; }

        // Foreign key
        public int PetId { get; set; } // the user's pet(s)
        
        // navigation property to the user's pet
        public Pet? Pet { get; set; } 

        [Required]
        public required string Username { get; set; } 
        [Required]
        public required string Email { get; set; }
        [Required]    
        public required string PasswordHash { get; set; } // hashed password for security
        public int PetCoins { get; set; } = 35; // virtual currency for the user to spend in the store
        public List<Product> UserInventory { get; set; } = new(); // list of products owned by the user 
     
        //public required List<Pet> Pets { get; set; } // list of pets owned by the user
        // user can only have one pet for now, but up to 3 later.
    }
}
