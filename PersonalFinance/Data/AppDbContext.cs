using Microsoft.EntityFrameworkCore;
using PersonalFinance.Models;

namespace PersonalFinance.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<FinancialGoal> FinancialGoals { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }
	}
}
