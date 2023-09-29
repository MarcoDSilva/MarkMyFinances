using MarkMyFinance.Application.DTO;
using MarkMyFinance.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarkMyFinance.API.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	[ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
	[ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
	[ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
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
			throw new NotImplementedException();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] string value)
		{
			throw new NotImplementedException();

		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] string value)
		{
			throw new NotImplementedException();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			throw new NotImplementedException();

		}
	}
}
