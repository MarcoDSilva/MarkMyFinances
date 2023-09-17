using AutoMapper;
using MarkMyFinance.Application.DTO;
using MarkMyFinance.Application.Services.Interfaces;
using MarkMyFinance.Domain.Entities;
using MarkMyFinance.Persistance.Repository.Interfaces;

namespace MarkMyFinance.Application.Services.Logic
{
	public class ExpensesService : IServices<ExpenseDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ExpensesService(IMapper mapper, IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<bool> AddAsync(ExpenseDto entity)
		{
			var expense = _mapper.Map<ExpenseDto, Expense>(entity);
			var wasExpenseAdded = await _unitOfWork.ExpensesRepository.CreateAsync(expense);

			return wasExpenseAdded;
		}

		public async Task<bool> EditAsync(ExpenseDto entity)
		{
			var expense = _mapper.Map<ExpenseDto, Expense>(entity);
			var wasEdited = await _unitOfWork.ExpensesRepository.UpdateAsync(expense);
			return wasEdited;
		}

		public async Task<List<ExpenseDto>> GetAllAsync()
		{
			var expenses = await _unitOfWork.ExpensesRepository.GetAllAsync();

			if (expenses.Count == 0)
				return new List<ExpenseDto>();

			var expensesDto = new List<ExpenseDto>();
			expenses.ForEach(exp => expensesDto.Add(_mapper.Map<Expense, ExpenseDto>(exp)));

			return expensesDto;
		}

		public async Task<ExpenseDto?> GetByID(int id)
		{
			var expense = await _unitOfWork.ExpensesRepository.GetByIdAsync(id);
			if (expense is null) return new ExpenseDto();

			var dto = _mapper.Map<Expense, ExpenseDto>(expense);
			return dto;
		}

		public Task<bool> RemoveAsync(ExpenseDto entity)
		{
			var expense = _mapper.Map<ExpenseDto, Expense>(entity);
			var wasRemoved = _unitOfWork.ExpensesRepository.DeleteAsync(expense);

			return wasRemoved;
		}
	}
}
