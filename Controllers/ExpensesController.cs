using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            var expenses = _appDbContext.Expenses.ToList();
            return View(expenses);
        }

        // Action Method to direct user to Create.cshtml page
        public IActionResult Create()
        {
            return View();
        }

        // Action Method to save changes to db
        [HttpPost]
        public IActionResult Create(Expenses expenses)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Expenses.Add(expenses);
                _appDbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
