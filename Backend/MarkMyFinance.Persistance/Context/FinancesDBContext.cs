using MarkMyFinance.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarkMyFinance.Persistance.Context
{
	public class FinancesDBContext : DbContext
	{
		public FinancesDBContext(DbContextOptions<FinancesDBContext> options) : base(options)
		{
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Expense> Expenses { get; set; }
		public DbSet<Income> Income { get; set; }
		public DbSet<Investment> Investments { get; set; }
		public DbSet<SubCategory> SubCategories { get; set; }
		public DbSet<Balance> Balance { get; set; }


		// SEEDING CATEGORIES FOR DB 
		private static List<Category> SeedCategories()
		{
			return new List<Category>()
			{
				new Category()
				{
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Id = 1,
					Name = "UNKOWN",
				},
				new Category()
				{
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Id = 2,
					Name = "Income",
				},
				new Category()
				{
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Id = 3,
					Name = "Home",
				},
				new Category()
				{
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Id = 4,
					Name = "Technology",
				},
				new Category()
				{
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Id = 5,
					Name = "Entertainment",
				},
				new Category()
				{
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Id = 6,
					Name = "Utilities",
				},
				new Category()
				{
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Id = 7,
					Name = "Transportation",
				},
				new Category()
				{
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Id = 8,
					Name = "Pets",
				},
				new Category()
				{
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Id = 9,
					Name = "Health",
				},
				new Category()
				{
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Id = 10,
					Name = "Everyday",
				}
			};
		}

		private static List<SubCategory> SeedSubCategories()
		{
			return new List<SubCategory>()
			{
				new SubCategory()
				{
					CategoryId = 1,
					Id = 1,
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Name = "UNKNOWN"
				},
				new SubCategory()
				{
					CategoryId = 2,
					Id = 2,
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Name = "Wages"
				},
				new SubCategory()
				{
					CategoryId = 2,
					Id = 3,
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Name = "Other"
				},
				new SubCategory()
				{
					CategoryId = 3,
					Id = 4,
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Name = "Rent"
				},
				new SubCategory()
				{
					CategoryId = 6,
					Id = 5,
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Name = "Electricity"
				},
				new SubCategory()
				{
					CategoryId = 6,
					Id = 6,
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Name = "Gas"
				},
				new SubCategory()
				{
					CategoryId = 6,
					Id = 7,
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Name = "Water"
				},
				new SubCategory()
				{
					CategoryId = 6,
					Id = 8,
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Name = "Internet"
				},
				new SubCategory()
				{
					CategoryId = 9,
					Id = 9,
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Name = "Food"
				}
			};
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Category>().HasData(SeedCategories());
			modelBuilder.Entity<SubCategory>().HasData(SeedSubCategories());
		}

	}
}
