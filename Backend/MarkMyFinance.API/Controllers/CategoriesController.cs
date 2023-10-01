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
	public class CategoriesController : ControllerBase
	{
		private readonly IServices<CategoryDto> _service;

		public CategoriesController(IServices<CategoryDto> service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var categories = await _service.GetAllAsync();
			return Ok(categories);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			if (id <= 0) return BadRequest(ErrorDescriptions.IdLowerThanOne);

			var category = await _service.GetByID(id);

			return category is null || category.Id <= 0 ? NotFound() : Ok(category);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CategoryRequest request)
		{
			var categoryDto = new CategoryDto()
			{
				CreatedAt = DateTime.UtcNow,
				UpdatedAt = DateTime.UtcNow,
				Name = request.Name
			};

			var categoryAdded = await _service.AddAsync(categoryDto);
			return categoryAdded ? Ok() : Problem();
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] CategoryRequest request)
		{
			var categoryDto = new CategoryDto()
			{
				CreatedAt = request.CreatedAt,
				UpdatedAt = request.UpdatedAt,
				Id = request.Id,
				Name = request.Name
			};

			var wasUpdated = await _service.EditAsync(categoryDto);
			return wasUpdated ? Ok() : Problem();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (id <= 0) return BadRequest(ErrorDescriptions.IdLowerThanOne);

			var wasCategoryDeleted = await _service.RemoveAsync(id);
			return wasCategoryDeleted ? Ok() : Problem();
		}
	}
}
