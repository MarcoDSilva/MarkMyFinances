using System.ComponentModel.DataAnnotations;

namespace MarkMyFinance.API.DTO
{
    public class CategoryCreateRequest
    {
		[Required, StringLength(50)]
		public string Name { get; set; } = "";
	}
}
