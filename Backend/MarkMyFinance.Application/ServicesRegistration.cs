using MarkMyFinance.Application.DTO;
using MarkMyFinance.Application.Services.Interfaces;
using MarkMyFinance.Application.Services.Logic;
using Microsoft.Extensions.DependencyInjection;

namespace MarkMyFinance.Application
{
	public static class ServicesRegistration
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<IServices<CategoryDto>, CategoryService>();
			services.AddScoped<IServices<ExpenseDto>, ExpensesService>();

			return services;
		}
	}
}
