using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Models
{
	public class FinancialGoal
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string Name { get; set; } = null!;

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal TargetAmount { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal CurrentAmount { get; set; }

		[Required]
		[MaxLength(3)]
		public string CurrencyCode { get; set; } = "PLN";

		public DateTime? Deadline { get; set; }
	}
}
