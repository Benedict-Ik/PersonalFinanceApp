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

        public async Task<Expenses> GetExpenseByIdAsync(Guid id)
        {
            //var expense = await _appDbContext.Expenses.FindAsync(id);
            var expense = await _appDbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);
            return expense;
        }


        public async Task UpdateExpenseAsync(Expenses updatedExpense)
        {
            var existingExpense = await _appDbContext.Expenses.FirstOrDefaultAsync(e => e.Id == updatedExpense.Id);

            if (existingExpense != null)
            {
                existingExpense.Description = updatedExpense.Description;
                existingExpense.Amount = updatedExpense.Amount;
                existingExpense.Category = updatedExpense.Category;
                existingExpense.Date = updatedExpense.Date;

                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Expense not found");
            }
        }


        public async Task DeleteExpenseByIdAsync(Guid id)
        {
            var expense = await GetExpenseByIdAsync(id);
            if (expense != null)
            {
                _appDbContext.Expenses.Remove(expense);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Expense not found");
            }
        }


    }
}
