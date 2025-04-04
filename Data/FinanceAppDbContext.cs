using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Models.Domain;

namespace PersonalFinanceApp.Data
{
    public class FinanceAppDbContext : DbContext
    {
        public FinanceAppDbContext(DbContextOptions<FinanceAppDbContext> options) : base(options)
        {
        }

        // DbSet for Expenses - Tables
        public DbSet<Expenses> Expenses { get; set; }
    }
}
