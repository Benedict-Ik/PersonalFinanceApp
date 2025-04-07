using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApp.Models.Domain;
using PersonalFinanceApp.Services;

namespace PersonalFinanceApp.Controllers
{
    [Route("Expenses")]
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expensesService;

        public ExpensesController(IExpensesService expensesService)
        {
            this._expensesService = expensesService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var expenses = await _expensesService.GetAllExpensesAsync();
                return View(expenses);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while retrieving expenses.";
                // Optionally log the error here
                return View("Error");
            }
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Expenses expenses)
        {
            if (!ModelState.IsValid)
            {
                return View(expenses);
            }

            try
            {
                await _expensesService.AddExpenseAsync(expenses);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Failed to create expense. Please try again.";
                return View("Error");
            }
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var expense = await _expensesService.GetExpenseByIdAsync(id);
                if (expense == null)
                {
                    return NotFound();
                }
                return View(expense);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Failed to load expense for editing.";
                return View("Error");
            }
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Update(Expenses expense)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", expense);
            }

            try
            {
                await _expensesService.UpdateExpenseAsync(expense);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "An error occurred while updating the expense.";
                return View("Error");
            }
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _expensesService.DeleteExpenseByIdAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Failed to delete the expense.";
                return View("Error");
            }
        }
    }
}
