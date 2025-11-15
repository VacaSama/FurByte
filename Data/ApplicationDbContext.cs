using FurByte.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FurByte.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
	// add and create things for the database here :)  

	public DbSet<Pet> Pets { get; set; }
	public DbSet<RehomeRequest> RehomeRequests { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<UserProduct> UserProducts { get; set; }

	// seed data for pets 
	// create a viewmodel for the rehome requests?? -- non :)

	/* This is a **special method** in your `DbContext` class.
	It’s called automatically by Entity Framework when building the model 
	(i.e., setting up classes map to the database).
	*/
	// protected override means you're **customizing** the default behavior.

	protected override void OnModelCreating(ModelBuilder builder)
	{
		// always include this line!
		base.OnModelCreating(builder);

		// the model we are building is for the Pet.cs
		builder.Entity<Pet>().HasData(
			new Pet
			{
				PetId = 1,
				PetName = "Rudy",
				PetType = "Cat",
				PetFee = default,
				Gender = PetGender.Male
			},

			new Pet 
			{
				PetId = 2,
				PetName = "Flower",
				PetType = "Cat",
				PetFee = default,
				Gender = PetGender.Female
			}

			);
	}

}
