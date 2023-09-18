namespace MarkMyFinance.Application.DTO.Common
{
	public abstract class IBaseTransaction : IBaseEntityDto
	{
		public string Description { get; set; } = "";
		public decimal Value { get; set; }
		public DateTime TransactionDate { get; set; }
		public int CategoryId { get; set; }
		public int SubCategoryId { get; set; }
	}
}
