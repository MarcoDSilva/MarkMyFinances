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
		public DbSet<Balance> Balances { get; set; }

	}
}
