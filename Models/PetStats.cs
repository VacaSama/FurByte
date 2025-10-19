namespace FurByte.Models;

public class PetStats : Pet
{
    public string PetMood { get; set; } = "Happy"; // mood of the pet, e.g., "Happy", "Sad", "Hungry", etc.
    public int Happiness { get; set; } = 50; // happiness level of the pet, ranges from 0 to 100
    public int Hunger { get; set; } = 50; // hunger level of the pet, ranges from 0 to 100
    public int Hygiene { get; set; } = 50; // hygiene level of the pet, ranges from 0 to 100
}
