using MarkMyFinance.Domain.Common;

namespace MarkMyFinance.Domain.Entities
{
	public class Balance : BaseEntity
	{
		public decimal InitialBalance { get; set; }
		public DateTime DateOfBudget { get; set; }
	}
}
