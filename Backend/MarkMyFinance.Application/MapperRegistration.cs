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
			});

			return mapConfig;
		}
	}
}
