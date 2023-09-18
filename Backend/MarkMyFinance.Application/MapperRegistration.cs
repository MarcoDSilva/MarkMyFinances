using AutoMapper;
using MarkMyFinance.Application.DTO;
using MarkMyFinance.Domain.Entities;

namespace MarkMyFinance.Application
{
	public static class MapperRegistration
	{
		public static MapperConfiguration RegisterMapper()
		{
			var mapConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<CategoryDto, Category>().ReverseMap();
				config.CreateMap<ExpenseDto, Expense>().ReverseMap();
				config.CreateMap<IncomeDto, Income>().ReverseMap();
				config.CreateMap<InvestmentDto, Investment>().ReverseMap();
				config.CreateMap<SubCategoryDto, SubCategory>().ReverseMap();
				config.CreateMap<BalanceDto, Balance>().ReverseMap();
			});

			return mapConfig;
		}
	}
}
