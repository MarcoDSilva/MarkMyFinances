using System.ComponentModel.DataAnnotations;

namespace MarkMyFinance.API.DTO
{
	public class BalanceCreateRequest
	{
		[Required]
		public decimal InitialBalance { get; set; }

		[Required]
		public DateTime DateOfBudget { get; set; }
	}
}
