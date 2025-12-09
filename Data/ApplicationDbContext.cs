using FurByte.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace FurByte.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
	// add and create things for the database here :)  

	public DbSet<Pet> Pets { get; set; }
	public DbSet<PetStats> PetStats { get; set; }
	public DbSet<RehomeRequest> RehomeRequests { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<UserProduct> UserProducts { get; set; }

	#region Student Notes
	/* This is a **special method** in your `DbContext` class.
	It’s called automatically by Entity Framework when building the model 
	(i.e., setting up classes map to the database).
	*/
	// protected override means you're **customizing** the default behavior.
	#endregion
	protected override void OnModelCreating(ModelBuilder builder)
	{
		// always include this line!
		base.OnModelCreating(builder);

		///<summary>
		/// An Entity that uses the model builder to seed data for Pets 
		/// </summary>
		builder.Entity<Pet>().HasData(
			new Pet
			{
				PetId = 1,
				PetName = "Rudy",
				PetType = "Cat",
				PetFee = 150,
				Gender = PetGender.Male
			},

			new Pet
			{
				PetId = 2,
				PetName = "Flower",
				PetType = "Cat",
				PetFee = 150,
				Gender = PetGender.Female
			}
			);


		///<summary>
		/// An Entity that uses the model builder to seed data for PetStats
		/// <see cref="PetStats"/> for default pet stats info i.e: Happiness value...etc
		/// </summary>
		

		builder.Entity<Pet>()
		.HasOne(p => p.Stats)
		.WithOne(s => s.Pet)
		.HasForeignKey<PetStats>(s => s.PetId);

		builder.Entity<PetStats>().HasData(
			new PetStats
			{
				PetStatsId = 1,
				PetId = 1, // for Rudy 
				Happiness = 50,
				Energy = 75,
				Hunger = 50,
				Hygiene = 50,
				PetMood = PetMood.Happy
			},
			new PetStats
			{
				PetStatsId = 2,
				PetId = 2, // for Flower
				Happiness = 75,
				Energy = 75,
				Hunger = 50,
				Hygiene = 50,
				PetMood = PetMood.Playful
			}
		);


		///<summary>
		/// An Entity that uses the model builder to seed data for Products 
		/// </summary>
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
			});

		///<summary>
		/// An Entity that uses the model builder to create many to many/ one to many
		/// realationships with RehomeRequest and ApplicationUser. 
		/// Cascade delete rules configured to restrict delete behavior, we want to transfer
		/// data not delete it. 
		/// </summary>
		
		#region Cascade Transfer Info
		/* previously there was an error because there were two cascade delete pathes 
		// this was caused by the two foreign keys in RehomeRequest MODEL
		// both linking to ApplicationUser(new owner and current owner), 
		// configuring relationships for RehomeRequest
		// using the builder */
		#endregion

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

