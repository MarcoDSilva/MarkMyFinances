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
		private Mock<Expense> _expense;
		private Mock<ExpenseDto> _expenseDto;

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
			_expense = new Mock<Expense>();
			_expenseDto = new Mock<ExpenseDto>();
		}

		[Test]
		public async Task CreatesExpense_ReceivesCorrectEntity_ReturnsTrue()
		{
			_expense.Object.Id = 1;
			_expenseDto.Object.Id = 1;

			_unitOfWork.Setup(exp => exp.ExpensesRepository.CreateAsync(It.IsAny<Expense>())).ReturnsAsync(true);

			var result = await _expenseService.AddAsync(_expenseDto.Object);

			Assert.That(result, Is.EqualTo(true));
		}

		[Test]
		public async Task EditsExpense_ReceivesCorrectEntity_ReturnsTrue()
		{
			_expenseDto.Object.Description = "NEW OBJ";
			_unitOfWork.Setup(exp => exp.ExpensesRepository.UpdateAsync(It.IsAny<Expense>())).ReturnsAsync(true);

			var result = await _expenseService.EditAsync(_expenseDto.Object);

			Assert.That(result, Is.EqualTo(true));
		}

		[Test]
		public async Task RemovesExpense_ReceiveExistingEntity_ReturnsTrue()
		{
			int id = 1;
			_unitOfWork.Setup(ex => ex.ExpensesRepository.GetByIdAsync(id)).ReturnsAsync(new Expense() { Id = id});
			_unitOfWork.Setup(exp => exp.ExpensesRepository.DeleteAsync(It.IsAny<Expense>())).ReturnsAsync(true);
			var result = await _expenseService.RemoveAsync(1);

			Assert.That(result, Is.EqualTo(true));
		}

		[Test]
		public void GetExpenseById_ReceivesCorrectId_ReturnsExpense()
		{
			int expenseId = 1;
			_unitOfWork.Setup(exp => exp.ExpensesRepository.GetByIdAsync(expenseId)).ReturnsAsync(_expense.Object);

			var result = _expenseService.GetByID(expenseId);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Id, Is.EqualTo(expenseId));
		}
	}
}