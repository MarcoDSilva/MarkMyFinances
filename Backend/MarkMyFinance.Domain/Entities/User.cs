using MarkMyFinance.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MarkMyFinance.Domain.Entities
{
	public class User : BaseEntity
	{
		[Required, StringLength(30)]
		public string Username { get; set; } = "";

		[Required, StringLength(255)]
		public string Email { get; set; } = "";

		[Required, StringLength(255)]
		public string Password { get; set; } = "";
	}
}
