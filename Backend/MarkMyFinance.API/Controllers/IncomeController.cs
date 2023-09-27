using MarkMyFinance.API.DTO;
using MarkMyFinance.Application.DTO;
using MarkMyFinance.Application.Services.Interfaces;
using MarkMyFinance.Domain.Entities;
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
	public class IncomeController : ControllerBase
	{
		private readonly IServices<IncomeDto> _incomeService;
		public IncomeController(IServices<IncomeDto> incomeService)
		{
			_incomeService = incomeService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var income = await _incomeService.GetAllAsync();
			return Ok(income);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetById(int id)
		{
			if (id <= 0) return Problem("Id cannot be lower than 0");

			var income = await _incomeService.GetByID(id);
			return income is null || income.Id <= 0 ? NotFound() : Ok(income);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] IncomeRequest request)
		{
			var incomeDto = new IncomeDto()
			{
				CategoryId = request.CategoryId,
				CreatedAt = DateTime.UtcNow,
				Description = request.Description,
				SubCategoryId = request.SubCategoryId,
				TransactionDate = request.TransactionDate,
				UpdatedAt = DateTime.UtcNow,
				Value = request.Value
			};

			var wasAdded = await _incomeService.AddAsync(incomeDto);

			return wasAdded ? Ok() : Problem();
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update([FromBody] ExpenseRequest request)
		{
			var incomeDto = new IncomeDto()
			{
				Id = request.Id,
				CategoryId = request.CategoryId,
				CreatedAt = DateTime.UtcNow,
				Description = request.Description,
				SubCategoryId = request.SubCategoryId,
				TransactionDate = request.TransactionDate,
				UpdatedAt = DateTime.UtcNow,
				Value = request.Value
			};

			var wasAdded = await _incomeService.EditAsync(incomeDto);

			return wasAdded ? Ok() : Problem();
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (id <= 0) return Problem("");

			var wasDeleted = await _incomeService.RemoveAsync(id);
			return wasDeleted ? Ok() : Problem();
		}
	}
}
