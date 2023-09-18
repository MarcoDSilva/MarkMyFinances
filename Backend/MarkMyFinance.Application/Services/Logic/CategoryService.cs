using MarkMyFinance.Application.DTO;
using MarkMyFinance.Persistance.Repository.Interfaces;
using MarkMyFinance.Application.Services.Interfaces;
using MarkMyFinance.Domain.Entities;
using AutoMapper;

namespace MarkMyFinance.Application.Services.Logic
{
	public class CategoryService : IServices<CategoryDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<bool> AddAsync(CategoryDto entity)
		{
			var category = new Category()
			{
				Name = entity.Name,
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			};

			var wasCategoryAdded = await _unitOfWork.CategoryRepository.CreateAsync(category);

			return wasCategoryAdded;
		}

		public async Task<bool> EditAsync(CategoryDto entity)
		{
			var category = _mapper.Map<CategoryDto, Category>(entity);
			var wasEdited = await _unitOfWork.CategoryRepository.UpdateAsync(category);
			return wasEdited;
		}

		public async Task<List<CategoryDto>> GetAllAsync()
		{
			var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
			var categoriesDto = new List<CategoryDto>();

			if (categories.Count == 0)
				return categoriesDto;

			categories.ForEach(ct => categoriesDto.Add(_mapper.Map<Category, CategoryDto>(ct)));

			return categoriesDto;
		}

		public async Task<CategoryDto?> GetByID(int id)
		{
			var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
			return category is null ? new CategoryDto() : _mapper.Map<Category, CategoryDto>(category);
		}

		public async Task<bool> RemoveAsync(CategoryDto entity)
		{
			var category = _mapper.Map<CategoryDto, Category>(entity);
			var wasRemoved = await _unitOfWork.CategoryRepository.DeleteAsync(category);

			return wasRemoved;
		}
	}
}
