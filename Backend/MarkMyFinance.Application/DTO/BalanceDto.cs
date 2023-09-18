using MarkMyFinance.Application.DTO.Common;

namespace MarkMyFinance.Application.DTO
{
	public class BalanceDto : IBaseEntityDto
	{
		public decimal InitialBalance { get; set; }
		public DateTime DateOfBudget { get; set; }
	}
}
