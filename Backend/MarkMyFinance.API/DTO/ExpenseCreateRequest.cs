using MarkMyFinance.API.DTO.Common;
using System.ComponentModel.DataAnnotations;

namespace MarkMyFinance.API.DTO
{
	public class ExpenseCreateRequest 
	{
		[Required, StringLength(50)]
		public string Description { get; set; } = "";

		[Range(0.01, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]

		public decimal Value { get; set; }

		[Required]
		public DateTime TransactionDate { get; set; }

		[Required]

		public int CategoryId { get; set; }
		[Required]
		public int SubCategoryId { get; set; }
	}
}
