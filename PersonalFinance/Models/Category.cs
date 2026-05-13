using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsIncome { get; set; } // True = Income, False = Expense
        public string? Icon { get; set; }
    }
}
