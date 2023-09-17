using MarkMyFinance.Application.DTO;
using MarkMyFinance.Persistance.Repository.Interfaces;
using MarkMyFinance.Application.Services.Interfaces;
using MarkMyFinance.Domain.Entities;

namespace MarkMyFinance.Application.Services.Logic
{
	public class CategoryService : IServices<CategoryDto>
	{
		private readonly IUnitOfWork _unitOfWork;

		public CategoryService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public Task<bool> AddAsync(CategoryDto entity)
		{
			throw new NotImplementedException();
		}

		public Task<bool> EditAsync(CategoryDto entity)
		{
			throw new NotImplementedException();
		}

		public Task<List<CategoryDto>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Category?> GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> RemoveAsync(CategoryDto entity)
		{
			throw new NotImplementedException();
		}
	}
}
