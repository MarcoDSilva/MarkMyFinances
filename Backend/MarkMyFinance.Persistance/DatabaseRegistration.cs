using MarkMyFinance.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MarkMyFinance.Persistance
{
	public static class DatabaseRegistration
	{
		public static IServiceCollection AddDbService(this IServiceCollection services)
		{
			services.AddDbContext<FinancesDBContext>(options =>
			{
				options.UseSqlite("Data Source=D:\\Coding\\MarkMyFinance\\Database\\MarkMyFinance.db");
			});

			return services;
		}
	}
}
