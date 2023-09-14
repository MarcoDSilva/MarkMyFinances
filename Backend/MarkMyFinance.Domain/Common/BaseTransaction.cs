﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarkMyFinance.Domain.Common
{

	public class BaseTransaction : BaseEntity
	{
		[Required, StringLength(250)]
		public string Description { get; set; } = "";

		[Required]
		public decimal Value { get; set; }

		[Required]
		public DateTime TransactionDate { get; set; }

		[Required, ForeignKey("Categories")]
		public int CategoryId { get; set; }

		[Required]
		public int SubCategoryId { get; set; }

	}
}

