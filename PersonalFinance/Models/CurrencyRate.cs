using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Models
{
	public class CurrencyRate
	{
		public int Id { get; set; }

		[Required]
		public string Code { get; set; } = "PLN"; // Np. "EUR"

		[Required]
		[Column(TypeName = "decimal(18,4)")]
		public decimal Rate { get; set; } // Kurs w stosunku do PLN

		public DateTime LastUpdated { get; set; }
	}
}
