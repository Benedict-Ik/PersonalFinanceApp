using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApp.Models.Domain;
using PersonalFinanceApp.Models.DTOs;
using PersonalFinanceApp.Services;

namespace PersonalFinanceApp.Controllers
{
    [Route("Expenses")]
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expensesService;
        private readonly IMapper _mapper;

        public ExpensesController(IExpensesService expensesService, IMapper mapper)
        {
            this._expensesService = expensesService;
            this._mapper = mapper;
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
        public async Task<IActionResult> Create(CreateExpenseDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var expense = _mapper.Map<Expenses>(dto);
                await _expensesService.AddExpenseAsync(expense);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Failed to create expense.");
                return View(dto);
            }
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var expense = await _expensesService.GetExpenseByIdAsync(id);
                if (expense == null)
                    return NotFound();

                var dto = _mapper.Map<UpdateExpenseDTO>(expense);
                return View(dto);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Failed to load expense.");
                return View();
            }
        }

        //[HttpPost("Edit")]
        [HttpPost("Update")]
        public async Task<IActionResult> Edit(UpdateExpenseDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var expense = _mapper.Map<Expenses>(dto);
                await _expensesService.UpdateExpenseAsync(expense);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Failed to update expense.");
                return View(dto);
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
                TempData["Error"] = "Failed to delete expense.";
                return RedirectToAction("Index");
            }
        }
    }
}
