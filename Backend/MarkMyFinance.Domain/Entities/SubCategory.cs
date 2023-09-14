using MarkMyFinance.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarkMyFinance.Domain.Entities
{
	public class SubCategory : BaseEntity
	{
		[Required, StringLength(50)]
		public string Name { get; set; } = "";

		[Required, ForeignKey(nameof(Category))]
		public int CategoryId { get; set; }
	}
}
