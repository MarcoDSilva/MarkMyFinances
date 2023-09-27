using MarkMyFinance.API.DTO;
using MarkMyFinance.Application.DTO;
using MarkMyFinance.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarkMyFinance.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
	[ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
	[ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
	public class ExpensesController : ControllerBase
	{
		private readonly IServices<ExpenseDto> _expenseService;
		public ExpensesController(IServices<ExpenseDto> service)
		{
			_expenseService = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var expenses = await _expenseService.GetAllAsync();
			return Ok(expenses);
		}

		[HttpGet()]
		[Route("{id:int}")]
		public async Task<IActionResult> GetById(int id)
		{
			if (id <= 0) return Problem("Id cannot be lower than 0");

			var expense = await _expenseService.GetByID(id);

			return expense is null || expense.Id <= 0 ? NotFound() : Ok(expense);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] ExpenseRequest expense)
		{
			var expenseDto = new ExpenseDto()
			{
				CategoryId = expense.CategoryId,
				Description = expense.Description,
				SubCategoryId = expense.SubCategoryId,
				TransactionDate = expense.TransactionDate,
				Value = expense.Value
			};

			var expenseAdded = await _expenseService.AddAsync(expenseDto);

			return expenseAdded ? Ok() : Problem();
		}

		[HttpPut()]
		public async Task<IActionResult> Update([FromBody] ExpenseRequest expense)
		{
			var expenseDto = new ExpenseDto()
			{
				CategoryId = expense.CategoryId,
				Description = expense.Description,
				SubCategoryId = expense.SubCategoryId,
				TransactionDate = expense.TransactionDate,
				Value = expense.Value,
				Id = expense.Id
			};

			var expenseEdited = await _expenseService.EditAsync(expenseDto);
			return expenseEdited ? Ok() : Problem();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var expenseDeleted = await _expenseService.RemoveAsync(id);
			return expenseDeleted ? Ok() : Problem();
		}
	}
}
