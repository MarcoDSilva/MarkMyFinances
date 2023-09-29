using MarkMyFinance.API.DTO.Common;
using System.ComponentModel.DataAnnotations;

namespace MarkMyFinance.API.DTO
{
	public class CategoryRequest : IBaseEntityDto
	{
		[Required, StringLength(50)]
		public string Name { get; set; } = "";
	}
}
