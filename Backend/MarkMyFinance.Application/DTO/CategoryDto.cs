namespace MarkMyFinance.Application.DTO
{
	public class CategoryDto
	{
		public int Id { get; set; }
		public string Name { get; set; } = "";
		public DateTime CreatedAt { get; set; }
		public DateTime ChangedAt { get; set; }
	}
}
