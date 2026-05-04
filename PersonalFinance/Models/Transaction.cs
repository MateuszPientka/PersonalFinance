using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinance.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public decimal Amount { get; set; }
        [Column(TypeName = "text")]  public TransactionType transactionType { get; set; } = TransactionType.Expense;
        public string Category { get; set; } = "Other";
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [MaxLength(255)]
        public string? Description { get; set; }

    }

    public enum TransactionType
    {
        Expense = 0,
        Income = 1
    }
}
