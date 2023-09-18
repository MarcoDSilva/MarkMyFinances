using AutoMapper;
using MarkMyFinance.Application.DTO;
using MarkMyFinance.Application.Services.Interfaces;
using MarkMyFinance.Domain.Entities;
using MarkMyFinance.Persistance.Repository.Interfaces;

namespace MarkMyFinance.Application.Services.Logic
{
	public class IncomeService : IServices<IncomeDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public IncomeService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<bool> AddAsync(IncomeDto entity)
		{
			var income = _mapper.Map<IncomeDto, Income>(entity);
			var wasIncomeAdded = await _unitOfWork.IncomeRepository.CreateAsync(income);

			return wasIncomeAdded;
		}

		public Task<bool> EditAsync(IncomeDto entity)
		{
			var income = _mapper.Map<IncomeDto, Income>(entity);
			var wasIncomeEdited = _unitOfWork.IncomeRepository.UpdateAsync(income);

			return wasIncomeEdited;
		}

		public async Task<List<IncomeDto>> GetAllAsync()
		{
			var incomeList = await _unitOfWork.IncomeRepository.GetAllAsync();
			var incomeListDto = new List<IncomeDto>();

			if (incomeList.Count == 0)
				return incomeListDto;

			incomeList.ForEach(inc => incomeListDto.Add(_mapper.Map<Income, IncomeDto>(inc)));

			return incomeListDto;
		}

		public async Task<IncomeDto?> GetByID(int id)
		{
			var income = await _unitOfWork.IncomeRepository.GetByIdAsync(id);

			return income is null ? new IncomeDto() : _mapper.Map<Income, IncomeDto>(income);
		}

		public async Task<bool> RemoveAsync(IncomeDto entity)
		{
			var income = _mapper.Map<IncomeDto, Income>(entity);

			var wasRemoved = await _unitOfWork.IncomeRepository.DeleteAsync(income);

			return wasRemoved;
		}
	}
}
