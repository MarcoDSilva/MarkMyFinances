using System.ComponentModel.DataAnnotations;
using MarkMyFinance.Domain.Common;

namespace MarkMyFinance.Domain.Entities
{
    public class Investment : BaseTransaction
    {
        [Required]
        public bool IsActive { get; set; }

        [Required, Range(0.0, 1000)]
        public decimal ExpectedReturn { get; set; }
    }
}
