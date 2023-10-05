using MarkMyFinance.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarkMyFinance.API.DTO
{
	public class SubCategoryCreateRequest
	{
		[Required, StringLength(50)]
		public string Name { get; set; } = "";

		[Required, ForeignKey(nameof(Category))]
		public int CategoryId { get; set; }
	}
}
