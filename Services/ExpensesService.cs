using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Data;
using PersonalFinanceApp.Models.Domain;

namespace PersonalFinanceApp.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly FinanceAppDbContext _appDbContext;

        public ExpensesService(FinanceAppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Expenses>> GetAllExpensesAsync()
        {
            var expenses = await _appDbContext.Expenses.ToListAsync();
            return expenses;
        }

        public async Task AddExpenseAsync(Expenses expense)
        {
            await _appDbContext.Expenses.AddAsync(expense);
            await _appDbContext.SaveChangesAsync();
        }

    }
}
