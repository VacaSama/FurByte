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

	// create a viewmodel for the rehome requests??
}
