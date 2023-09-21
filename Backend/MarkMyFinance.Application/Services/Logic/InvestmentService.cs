using AutoMapper;
using MarkMyFinance.Application.DTO;
using MarkMyFinance.Application.Services.Interfaces;
using MarkMyFinance.Domain.Entities;
using MarkMyFinance.Persistance.Repository.Interfaces;

namespace MarkMyFinance.Application.Services.Logic
{
	public class InvestmentService : IServices<InvestmentDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public InvestmentService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<bool> AddAsync(InvestmentDto entity)
		{
			var investment = _mapper.Map<InvestmentDto, Investment>(entity);
			investment.CreatedAt = DateTime.UtcNow;
			investment.UpdatedAt = DateTime.UtcNow;

			var wasCreated = await _unitOfWork.InvestmentRepository.CreateAsync(investment);
			return wasCreated;
		}

		public async Task<bool> EditAsync(InvestmentDto entity)
		{
			var investment = _mapper.Map<InvestmentDto, Investment>(entity);
			var wasSaved = await _unitOfWork.InvestmentRepository.UpdateAsync(investment);

			return wasSaved;
		}

		public async Task<List<InvestmentDto>> GetAllAsync()
		{
			var investmentList = await _unitOfWork.InvestmentRepository.GetAllAsync();
			var investmentDto = new List<InvestmentDto>();

			if (investmentList.Count == 0)
				return investmentDto;

			investmentList.ForEach(inv => investmentDto.Add(_mapper.Map<Investment, InvestmentDto>(inv)));

			return investmentDto;
		}

		public async Task<InvestmentDto?> GetByID(int id)
		{
			var investment = await _unitOfWork.InvestmentRepository.GetByIdAsync(id);

			return investment is null ? new InvestmentDto() : _mapper.Map<Investment, InvestmentDto>(investment);
		}

		public async Task<bool> RemoveAsync(int id)
		{
			var investment = await _unitOfWork.InvestmentRepository.GetByIdAsync(id);
			bool wasRemoved = false;

			if (investment is not null && investment.Id > 0)
				wasRemoved = await _unitOfWork.InvestmentRepository.DeleteAsync(investment);

			return wasRemoved;
		}
	}
}
