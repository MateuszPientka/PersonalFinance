using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Models
{
	public class CurrencyRate
	{
		public int Id { get; set; }

		[Required]
		public string Code { get; set; } = "PLN";

		[Required]
		[Column(TypeName = "decimal(18,4)")]
		public decimal Rate { get; set; }

		public DateTime LastUpdated { get; set; }
	}
}
