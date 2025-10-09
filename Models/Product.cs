namespace FurByte.Models
{
    /// <summary>
    /// The Product model represents a store entity that sells pets, pet food, 
    /// and toys to the user for various pets. It serves as a central hub for 
    /// users to browse and purchase items for their pets.
    /// </summary>
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
