using PersonalFinanceApp.Models.Domain;

namespace PersonalFinanceApp.Services
{
    public interface IExpensesService
    {
        // Method signatures
        Task<IEnumerable<Expenses>> GetAllExpensesAsync();
        Task AddExpenseAsync(Expenses expense);
        Task<Expenses> GetExpenseByIdAsync(Guid id);
        Task UpdateExpenseAsync(Expenses expense);
        Task DeleteExpenseByIdAsync(Guid id);
        IQueryable GetChartData();
        //List<object> GetChartData();
    }
}
