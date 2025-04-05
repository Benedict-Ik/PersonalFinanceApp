using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApp.Models.Domain;
using PersonalFinanceApp.Services;

namespace PersonalFinanceApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expensesService;

        public ExpensesController(IExpensesService expensesService)
        {
            this._expensesService = expensesService;
        }

        // Action Method to direct user to Index.cshtml page which basically retrieves a list of all expenses
        public async Task<IActionResult> Index()
        {
            var expenses = await _expensesService.GetAllExpensesAsync();
            return View(expenses);
        }

        // Action Method to direct user to Create.cshtml page
        public IActionResult Create()
        {
            return View();
        }

        // Action Method to save changes to db
        [HttpPost]
        public async Task<IActionResult> Create(Expenses expenses)
        {
            if (ModelState.IsValid)
            {
                await _expensesService.AddExpenseAsync(expenses);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
