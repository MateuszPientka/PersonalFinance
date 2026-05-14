using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Models
{
    public class FinancialGoal
    {
        public int Id { get; set; }
        public string Name { get; set; } = "New Goal";
        public decimal TargetAmount { get; set; }
    }
}
