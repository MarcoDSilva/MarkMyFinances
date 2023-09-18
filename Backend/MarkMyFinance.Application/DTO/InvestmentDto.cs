using MarkMyFinance.Application.DTO.Common;

namespace MarkMyFinance.Application.DTO
{
    public class InvestmentDto : IBaseTransaction
	{	
		public bool IsActive { get; set; }
		public decimal ExpectedReturn { get; set; }
	}
}
