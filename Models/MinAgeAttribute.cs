using System.ComponentModel.DataAnnotations;

namespace FurByte.Models;
/// <summary>
/// The minimum age validation attribute. Inherits from ValidationAttribute,
/// This specifies the minimum age required for a user.
/// </summary>
public class MinAgeAttribute : ValidationAttribute
{
	// private field to hold the minimum age value
	private readonly int _minAge; 

	// create a contructor that takes the min age as a parameter
	public MinAgeAttribute(int minAge)
	{
		// the private field `_minAge`(above) is set to the value
		// of the parameter `minAge`
		_minAge = minAge;
	}

	// Nxt, overrise the IsValid method from the ValidationAttribute
	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		if (value is DateOnly birthDate)
		{
			var today = DateOnly.FromDateTime(DateTime.Today);
			int age = today.Year - birthDate.Year;
			// if the birthdate has not occurred yet, 
			// subtract one from the age
			if (birthDate > today.AddYears(age--)){
				age--;
			}

			if (age >= _minAge)
			{
				return ValidationResult.Success;
			}

		}
		return new ValidationResult($"You must be at least {_minAge}, to register.");
	}
}
