using System.ComponentModel.DataAnnotations;

namespace FurByte.Models;
/// <summary>
/// The minimum age validation attribute. Inherits from ValidationAttribute,
/// This specifies the minimum age required for a user.
/// </summary>
public class MinAgeAttribute : ValidationAttribute
{
}
