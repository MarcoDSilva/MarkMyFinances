using MarkMyFinance.API.DTO;
using MarkMyFinance.API.Shared;
using MarkMyFinance.Application.DTO;
using MarkMyFinance.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarkMyFinance.API.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	[ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
	[ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
	[ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
	[ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
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
			if (id <= 0) return BadRequest(ErrorDescriptions.IdLowerThanOne);

			var expense = await _expenseService.GetByID(id);

			return expense is null || expense.Id <= 0 ? NotFound() : Ok(expense);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] ExpenseCreateRequest expense)
		{
			var expenseDto = new ExpenseDto()
			{
				CategoryId = expense.CategoryId,
				Description = expense.Description,
				SubCategoryId = expense.SubCategoryId,
				TransactionDate = expense.TransactionDate,
				Value = expense.Value,
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			};

			var expenseAdded = await _expenseService.AddAsync(expenseDto);

			return expenseAdded ? Ok() : Problem();
		}

		[HttpPut()]
		public async Task<IActionResult> Update([FromBody] ExpenseUpdateRequest expense)
		{
			var expenseDto = new ExpenseDto()
			{
				CategoryId = expense.CategoryId,
				Description = expense.Description,
				SubCategoryId = expense.SubCategoryId,
				TransactionDate = expense.TransactionDate,
				Value = expense.Value,
				Id = expense.Id,
				CreatedAt = expense.CreatedAt,
				UpdatedAt = DateTime.Now
			};

			var expenseEdited = await _expenseService.EditAsync(expenseDto);
			return expenseEdited ? Ok() : Problem();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (id <= 0) return BadRequest(ErrorDescriptions.IdLowerThanOne);

			var expenseDeleted = await _expenseService.RemoveAsync(id);
			return expenseDeleted ? Ok() : Problem();
		}
	}
}
