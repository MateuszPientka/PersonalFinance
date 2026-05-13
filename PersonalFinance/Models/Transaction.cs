using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinance.Models
{
	public class Transaction
	{
		[Key]
		public int Id { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

		[Required]
		[MaxLength(3)]
		public string CurrencyCode { get; set; } = "PLN"; // Np. PLN, EUR, USD

		[Required]
		public DateTime Date { get; set; }

		[MaxLength(200)]
		public string? Description { get; set; }

		[Required]
		public TransactionType Type { get; set; } // Enum: Income / Expense

		// Relacja do Kategorii
		[Required]
		public int CategoryId { get; set; }
		public Category Category { get; set; } = null!;
	}

	public enum TransactionType
	{
		Income,
		Expense
	}
}
