using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace FurByte.Models;

public class SeedData
{
	public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) {
		// an array of strings for roles to make
		string[] roles = new[] { "Overseer", "User" };

		foreach (string role in roles)
		{
			// if we wait and the role does not exist, 
			// create it. 
			if (!await roleManager.RoleExistsAsync(role))
			{
				// create roles
				var identityRole = new IdentityRole(role);
				var result = await roleManager.CreateAsync(identityRole);
				// if the result did not succeed, throw custom exception
				if (!result.Succeeded)
				{
					// failed to create role
					throw new Exception($"Failed to create role '{role}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
				}
			}	
		}

		// create sample overseer to test login/logout
		string overseerEmail = "FurByteOverseer@furbyte.pet"; 
		var overseer = await userManager.FindByEmailAsync(overseerEmail);

		if (overseer == null)
		{
			overseer = new ApplicationUser
			{
				FirstName = "Anonymous",
				LastName = "Overseer",
				UserName = "Anon.0verseer",
				Email = overseerEmail,
				EmailConfirmed = true,
				DateOfBirth = DateOnly.ParseExact("1990-01-01", "yyyy-MM-dd"), 
				Rank = 5,
				// give the overseer a large amount of PetCoins to test purchases
				PetCoins = 9999
			};

			// here is the default password for the overseer
			var createResult = await userManager.CreateAsync(overseer, "FurByt30verseer"); 
			if (!createResult.Succeeded)
			{
				throw new Exception($"Failed to create overseer user: {string.Join(", ", createResult.Errors.Select(e => e.Description))}");
			}
		}

		// iff the overseer is not in the Overseer role, add them to it.
		if (!await userManager.IsInRoleAsync(overseer, "Overseer"))
		{
			var addRoleResult = await userManager.AddToRoleAsync(overseer, "Overseer");
			if (!addRoleResult.Succeeded)
			{
				throw new Exception($"Failed to add overseer to role: {string.Join(", ", addRoleResult.Errors.Select(e => e.Description))}");
			}
		}
	}
}
