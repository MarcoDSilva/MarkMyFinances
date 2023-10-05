using MarkMyFinance.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarkMyFinance.API.DTO
{
	public class IncomeCreateRequest
	{
		[Required, StringLength(50)]
		public string Description { get; set; } = "";

		[Range(0.01, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]

		public decimal Value { get; set; }

		[Required]
		public DateTime TransactionDate { get; set; }

		[Required, ForeignKey(nameof(Category))]
		public int CategoryId { get; set; }

		[Required, ForeignKey(nameof(SubCategory))]
		public int SubCategoryId { get; set; }
	}
}
