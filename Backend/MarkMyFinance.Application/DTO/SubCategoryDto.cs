using MarkMyFinance.Application.DTO.Common;

namespace MarkMyFinance.Application.DTO
{
	public class SubCategoryDto : IBaseEntityDto
	{
		public string Name { get; set; } = "";
		public int CategoryId { get; set; }
		public string CategoryName { get; set; } = "";
	}
}
