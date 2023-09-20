using AutoMapper;
using MarkMyFinance.Application.DTO;
using MarkMyFinance.Application.Services.Interfaces;
using MarkMyFinance.Application.Services.Logic;
using MarkMyFinance.Domain.Entities;
using MarkMyFinance.Persistance.Repository.Interfaces;
using Moq;

namespace MarkMyFinances.UnitTesting
{
	[TestFixture]
	public class ExpenseServiceTests
	{
		// DI classes
		private Mock<IUnitOfWork> _unitOfWork;
		private Mock<IMapper> _mapper;
		private IServices<ExpenseDto> _expenseService;

		// objects required for test
		private Expense _expense;
		private ExpenseDto _expenseDto;

		public ExpenseServiceTests()
		{
			_unitOfWork = new Mock<IUnitOfWork>();
			_mapper = new Mock<IMapper>();
			_expenseService = new ExpensesService(_mapper.Object, _unitOfWork.Object);

			Setup();
		}


		[SetUp]
		public void Setup()
		{
			_expense = new Expense()
			{
				Id = 1,
				CategoryId = 1,
				CreatedAt = DateTime.UtcNow,
				UpdatedAt = DateTime.UtcNow,
				Description = "UNKNOWN",
				SubCategoryId = 1,
				TransactionDate = new DateTime().AddDays(2),
				Value = 100
			};

			_expenseDto = new ExpenseDto()
			{
				Id = 1,
				CategoryId = 1,
				CreatedAt = DateTime.UtcNow,
				UpdatedAt = DateTime.UtcNow,
				Description = "UNKNOWN",
				SubCategoryId = 1,
				TransactionDate = new DateTime().AddDays(2),
				Value = 100
			};
		}

		[Test]
		public async Task CreatesExpense_ReceivesCorrectEntity_ReturnsTrue()
		{
			_expense.Id = 1;
			_expenseDto.Id = 1;

			_unitOfWork.Setup(exp => exp.ExpensesRepository.CreateAsync(_expense)).ReturnsAsync(true);

			var result = await _expenseService.AddAsync(_expenseDto);

			Assert.That(result, Is.EqualTo(true));
		}

		[Test]
		public async Task EditsExpense_ReceivesCorrectEntity_ReturnsTrue()
		{
			_expense.Description = "NEW OBJ";
			_expenseDto.Description = "NEW OBJ";

			_unitOfWork.Setup(exp => exp.ExpensesRepository.UpdateAsync(_expense)).ReturnsAsync(true);

			var result = await _expenseService.EditAsync(_expenseDto);

			Assert.That(result, Is.EqualTo(true));
		}

		[Test]
		public async Task RemovesExpense_ReceivesCorrectEntity_ReturnsTrue()
		{	
			_unitOfWork.Setup(exp => exp.ExpensesRepository.DeleteAsync(_expense)).ReturnsAsync(true);

			var result = await _expenseService.RemoveAsync(_expenseDto);

			Assert.That(result, Is.EqualTo(true));
		}

		[Test]
		public void GetExpenseById_ReceivesCorrectId_ReturnsExpense()
		{
			int expenseId = 1;
			_unitOfWork.Setup(exp => exp.ExpensesRepository.GetByIdAsync(expenseId)).ReturnsAsync(_expense);

			var result = _expenseService.GetByID(expenseId);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Id, Is.EqualTo(expenseId));
		}
	}
}