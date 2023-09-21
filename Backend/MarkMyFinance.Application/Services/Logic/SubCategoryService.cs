using AutoMapper;
using MarkMyFinance.Application.DTO;
using MarkMyFinance.Application.Services.Interfaces;
using MarkMyFinance.Domain.Entities;
using MarkMyFinance.Persistance.Repository.Interfaces;

namespace MarkMyFinance.Application.Services.Logic
{
	public class SubCategoryService : IServices<SubCategoryDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public SubCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<bool> AddAsync(SubCategoryDto entity)
		{
			var subCategory = _mapper.Map<SubCategoryDto, SubCategory>(entity);
			var wasAdded = await _unitOfWork.SubCategoryRepository.CreateAsync(subCategory);

			return wasAdded;
		}

		public async Task<bool> EditAsync(SubCategoryDto entity)
		{
			var subCategory = _mapper.Map<SubCategoryDto, SubCategory>(entity);
			var wasEdited = await _unitOfWork.SubCategoryRepository.UpdateAsync(subCategory);

			return wasEdited;
		}

		public async Task<List<SubCategoryDto>> GetAllAsync()
		{
			var subCategoryList = await _unitOfWork.SubCategoryRepository.GetAllAsync();
			var listDto = new List<SubCategoryDto>();

			if (subCategoryList.Count == 0)
				return listDto;

			subCategoryList.ForEach(cat => listDto.Add(_mapper.Map<SubCategory, SubCategoryDto>(cat)));
			return listDto;
		}

		public async Task<SubCategoryDto?> GetByID(int id)
		{
			var subCategory = await _unitOfWork.SubCategoryRepository.GetByIdAsync(id);
			return subCategory is null
				? new SubCategoryDto() : _mapper.Map<SubCategory, SubCategoryDto>(subCategory);
		}

		public async Task<bool> RemoveAsync(int id)
		{
			var subCategory = await _unitOfWork.SubCategoryRepository.GetByIdAsync(id);
			bool wasRemoved = false;

			if (subCategory is not null && subCategory.Id > 0)
				wasRemoved = await _unitOfWork.SubCategoryRepository.DeleteAsync(subCategory);

			return wasRemoved;
		}
	}
}
