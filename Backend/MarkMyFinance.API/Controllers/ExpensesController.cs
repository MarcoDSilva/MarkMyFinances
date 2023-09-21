using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarkMyFinance.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExpensesController : ControllerBase
	{

		[HttpGet]
		public IEnumerable<string> GetAll()
		{
			return new string[] { "value1", "value2" };
		}

		[HttpGet()]
		[Route("{id:int}")]
		public string GetById(int id)
		{
			return "value";
		}

		[HttpPost]
		public void Create([FromBody] string value)
		{
		}

		[HttpPut("{id}")]
		public void Update(int id, [FromBody] string value)
		{
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{

		}
	}
}
