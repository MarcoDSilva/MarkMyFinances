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

	public class SubCategoryController : ControllerBase
	{
		private readonly IServices<SubCategoryDto> _service;
		private readonly IServices<CategoryDto> _categoryService;

		public SubCategoryController(IServices<SubCategoryDto> subCategories,
									IServices<CategoryDto> categories)
		{
			_service = subCategories;
			_categoryService = categories;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var subCategories = await _service.GetAllAsync();

			if (subCategories is null || subCategories.Count <= 0)
				return Ok(subCategories);

			var categories = await _categoryService.GetAllAsync();
			var listOfCategories = categories.ToDictionary(c => c.Id, x => x.Name);

			foreach (var subCategory in subCategories)
			{
				subCategory.CategoryName = listOfCategories.ContainsKey(subCategory.CategoryId) ?
					listOfCategories[subCategory.CategoryId] : "UNKOWN";
			}

			return Ok(subCategories);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			if (id <= 0) return BadRequest(ErrorDescriptions.IdLowerThanOne);

			var subCategory = await _service.GetByID(id);

			return subCategory is null || subCategory.Id <= 0 ? NotFound() : Ok(subCategory);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] SubCategoryRequest request)
		{
			var subCategoryDto = new SubCategoryDto()
			{
				CreatedAt = DateTime.UtcNow,
				UpdatedAt = DateTime.UtcNow,
				Name = request.Name,
				CategoryId = request.CategoryId,
			};

			var subCategoryAdded = await _service.AddAsync(subCategoryDto);
			return subCategoryAdded ? Ok() : Problem();
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] SubCategoryRequest request)
		{
			var subCategoryDto = new SubCategoryDto()
			{
				CreatedAt = request.CreatedAt,
				UpdatedAt = request.UpdatedAt,
				Name = request.Name,
				CategoryId = request.CategoryId,
				Id = request.Id
			};

			var subCategoryAdded = await _service.EditAsync(subCategoryDto);
			return subCategoryAdded ? Ok() : Problem();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (id <= 0) return BadRequest(ErrorDescriptions.IdLowerThanOne);

			var wasSubCategoryDeleted = await _service.RemoveAsync(id);
			return wasSubCategoryDeleted ? Ok() : Problem();
		}
	}
}
