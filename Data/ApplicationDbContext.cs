using FurByte.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FurByte.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{   
	public DbSet<Pet> Pets { get; set; }
	// create RehomeRequests
	public DbSet<Product> Products { get; set; }
	public DbSet<UserProduct> UserProducts { get; set; }
}
