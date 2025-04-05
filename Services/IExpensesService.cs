using PersonalFinanceApp.Models.Domain;

namespace PersonalFinanceApp.Services
{
    public interface IExpensesService
    {
        // Method signatures
        Task<IEnumerable<Expenses>> GetAllExpensesAsync();
        Task AddExpenseAsync(Expenses expense);
    }
}
