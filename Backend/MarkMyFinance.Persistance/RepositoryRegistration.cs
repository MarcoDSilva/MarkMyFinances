using MarkMyFinance.Domain.Entities;
using MarkMyFinance.Domain.Interfaces;
using MarkMyFinance.Persistance.Repository;
using MarkMyFinance.Persistance.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MarkMyFinance.Persistance
{
	public static class RepositoryRegistration
	{
		public static IServiceCollection AddRepository(this IServiceCollection services)
		{
			services
				.AddScoped<IRepository<Balance>, BalanceRepository>()
				.AddScoped<IRepository<Category>, CategoryRepository>()
				.AddScoped<IRepository<Expense>, ExpensesRepository>()
				.AddScoped<IRepository<Income>, IncomeRepository>()
				.AddScoped<IRepository<Investment>, InvestmentRepository>()
				.AddScoped<IRepository<SubCategory>, SubCategoryRepository>()
				.AddScoped<IUnitOfWork, UnitOfWork>();

			return services;
		}
	}
}
