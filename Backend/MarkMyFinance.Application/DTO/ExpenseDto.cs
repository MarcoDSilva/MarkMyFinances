using System.ComponentModel.DataAnnotations;

namespace MarkMyFinance.Application.DTO
{
	public class ExpenseDto
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public string Description { get; set; } = "";
		public decimal Value { get; set; }
		public DateTime TransactionDate { get; set; }
		public int CategoryId { get; set; }
		public int SubCategoryId { get; set; }
	}
}
