using AutoMapper;
using MarkMyFinance.Application.DTO;
using MarkMyFinance.Application.Services.Interfaces;
using MarkMyFinance.Domain.Entities;
using MarkMyFinance.Persistance.Repository.Interfaces;

namespace MarkMyFinance.Application.Services.Logic
{
	public class BalanceService : IServices<BalanceDto>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public BalanceService(IMapper mapper, IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<bool> AddAsync(BalanceDto entity)
		{
			var balance = _mapper.Map<BalanceDto, Balance>(entity);
			var wasAdded = await _unitOfWork.BalanceRepository.CreateAsync(balance);

			return wasAdded;
		}

		public async Task<bool> EditAsync(BalanceDto entity)
		{
			var balance = _mapper.Map<BalanceDto, Balance>(entity);
			var wasEdited = await _unitOfWork.BalanceRepository.UpdateAsync(balance);

			return wasEdited;
		}

		public async Task<List<BalanceDto>> GetAllAsync()
		{
			var balanceList = await _unitOfWork.BalanceRepository.GetAllAsync();
			var listDto = new List<BalanceDto>();

			if (balanceList.Count == 0)
				return listDto;

			balanceList.ForEach(bal => listDto.Add(_mapper.Map<Balance, BalanceDto>(bal)));
			return listDto;
		}

		public async Task<BalanceDto?> GetByID(int id)
		{
			var balance = await _unitOfWork.BalanceRepository.GetByIdAsync(id);
			return balance is null
				? new BalanceDto() : _mapper.Map<Balance, BalanceDto>(balance);
		}

		public async Task<bool> RemoveAsync(BalanceDto entity)
		{
			var balance = _mapper.Map<BalanceDto, Balance>(entity);
			var wasRemoved = await _unitOfWork.BalanceRepository.DeleteAsync(balance);

			return wasRemoved;
		}
	}
}
