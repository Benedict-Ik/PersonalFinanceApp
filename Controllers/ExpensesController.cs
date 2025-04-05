using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Data;
using PersonalFinanceApp.Models.Domain;

namespace PersonalFinanceApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly FinanceAppDbContext _appDbContext;

        public ExpensesController(FinanceAppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        // Action Method to direct user to Index.cshtml page which basically retrieves a list of all expenses
        public async Task<IActionResult> Index()
        {
            var expenses = await _appDbContext.Expenses.ToListAsync();
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
                await _appDbContext.Expenses.AddAsync(expenses);
                _appDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
