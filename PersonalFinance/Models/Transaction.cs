using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public bool IsIncome { get; set; } = false;
        public string Category { get; set; } = "Other";
        public DateTime Date { get; set; } = DateTime.Now;
        [MaxLength(255)]
        public string? Description { get; set; }

    }
}
