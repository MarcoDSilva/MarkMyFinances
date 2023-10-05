using MarkMyFinance.API.DTO.Common;
using System.ComponentModel.DataAnnotations;

namespace MarkMyFinance.API.DTO
{
	public class BalanceUpdateRequest : IBaseEntityDto
	{
		[Required]
		public decimal InitialBalance { get; set; }

		[Required]
		public DateTime DateOfBudget { get; set; }
	}
}
