using ArtisanTech.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtisanTech.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Category> Categories { get; set; }

		public DbSet<Product> Products { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().HasData(
				new Category { CategoryId = 1, Name = "Graphics Cards", DisplayOrder = 1 },
				new Category { CategoryId = 2, Name = "Motherboard", DisplayOrder = 2 },
				new Category { CategoryId = 3, Name = "RAM", DisplayOrder = 3 }
				);

			modelBuilder.Entity<Product>().HasData(
				new Product { Id = 1, Name = "NVIDIA GeForce RTX 3080", Description = "The GPU operates at a frequency of 1440 MHz, which can be boosted up to 1710 MHz. The memory runs at 1188 MHz (19 Gbps effective).", Price = 1200000, Company = "NVIDIA", CategoryId = 1, ImageUrl = "" },
				new Product { Id = 2, Name = "GIGABYTE Z790 AORUS PRO X ATX Motherboard", Description = "X marks the 14th generation! Introducing the AORUS Z790 X Gen Motherboards, the most powerful platforms ever built for the Intel® Core™ 14th Gen processors. With the leading performance in DDR5 memory, the upgraded DIY-friendly innovations, and the all-new BIOS redesigned as user-centered, the AORUS Z790 X Gen Motherboards are built to fully unleash the next-gen power.", Price = 60000, Company = "GIGABYTE", CategoryId = 2, ImageUrl = "" },
				new Product { Id = 3, Name = "AMD Ryzen 9 5950X Processor", Description = "The AMD Ryzen 9 5950X is a high-performance processor with 16 cores and 32 threads. It has a base clock speed of 3.4 GHz and can boost up to 4.9 GHz. The processor is built on the AMD \"Zen 3\" core architecture and comes with a 64MB L3 cache and an 8MB L2 cache.", Price = 70000, Company = "AMD", CategoryId = 3, ImageUrl = "" }
				);
		}
	}
}
