using MarkMyFinance.API.DTO;
using MarkMyFinance.API.Shared;
using MarkMyFinance.Application.DTO;
using MarkMyFinance.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

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

	public class BalanceController : ControllerBase
	{
		private readonly IServices<BalanceDto> _services;

		public BalanceController(IServices<BalanceDto> services)
		{
			_services = services;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var balances = await _services.GetAllAsync();
			return Ok(balances);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			if (id <= 0) return BadRequest(ErrorDescriptions.IdLowerThanOne);
			var balance = await _services.GetByID(id);

			return balance is null || balance.Id <= 0 ? NotFound() : Ok(balance);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] BalanceCreateRequest request)
		{
			var balanceDto = new BalanceDto()
			{
				CreatedAt = DateTime.UtcNow,
				DateOfBudget = request.DateOfBudget,
				InitialBalance = request.InitialBalance,
				UpdatedAt = DateTime.UtcNow,
			};

			var balanceAdded = await _services.AddAsync(balanceDto);

			return balanceAdded ? Ok() : Problem();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] BalanceUpdateRequest request)
		{
			var balanceDto = new BalanceDto()
			{
				CreatedAt = request.CreatedAt,
				DateOfBudget = request.DateOfBudget,
				InitialBalance = request.InitialBalance,
				UpdatedAt = request.UpdatedAt,
				Id = request.Id,
			};

			var balanceEdited = await _services.EditAsync(balanceDto);

			return balanceEdited ? Ok() : Problem();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (id <= 0) return BadRequest(ErrorDescriptions.IdLowerThanOne);

			var balanceDeleted = await _services.RemoveAsync(id);
			return balanceDeleted ? Ok() : Problem();
		}
	}
}
