namespace MarkMyFinance.Application.DTO.Common
{
    public abstract class IBaseEntityDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
