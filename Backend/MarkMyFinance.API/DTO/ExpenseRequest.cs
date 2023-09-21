namespace MarkMyFinance.API.DTO
{
	public class ExpenseRequest
	{
		public string Description { get; set; } = "";
		public decimal Value { get; set; }
		public DateTime TransactionDate { get; set; }
		public int CategoryId { get; set; }
		public int SubCategoryId { get; set; }
	}
}
