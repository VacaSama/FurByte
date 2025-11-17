using FurByte.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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

		///
		///
		///
		builder.Entity<Product>().HasData(
			new Product
			{
				ProductId = 1, 
				ProductName = "Generic Pet Food",
				Description = "Basic pet food, cheap and filling." +
				" For all pet types",
				Category = "Pet Food",
				ImageUrl = "~/images/products/petfood_basic.png",
				Price = 50
			},

			new Product {
				ProductId = 2,
				ProductName = "Golden Boy'o Biscuits",
				Description = "These awesome treats bring all the pets to the yard..." +
				"seriously where did they come from.",
				Category = "Treats",
				ImageUrl = "~/images/products/treats_golden.png",
				Price = 75
			},

			new Product
			{
				ProductId = 3,
				ProductName = "Used Squeaky Toy",
				Description = "Creepy but squeaky!",
				Category = "Toys",
				ImageUrl = "~/images/products/squeakytoy_used.png",
				Price = 45
			},
			
			new Product
			{
				ProductId = 4,
				ProductName = "Pet Shampoo",
				Description = "Keeps your pet shiny and clean.",
				Category = "Hygiene",
				ImageUrl = "~/images/products/pet_shampoo.png",
				Price = 75
			}
			);
		// previously there was an error because there were two cascade delete pathes 
		// this was caused by the two foreign keys in RehomeRequest MODEL
		// both linking to ApplicationUser(new owner and current owner), 
		// configuring relationships for RehomeRequest
		// using the builder
		builder.Entity<RehomeRequest>()
			.HasOne(r => r.Owner)
			.WithMany()
			.HasForeignKey(r => r.OwnerId)
			.OnDelete(DeleteBehavior.Restrict); // or NoAction ???

		builder.Entity<RehomeRequest>()
			.HasOne(r => r.NewOwner)
			.WithMany()
			.HasForeignKey(r => r.NewOwnerId)
			.OnDelete(DeleteBehavior.Restrict);
			
	} 
}
