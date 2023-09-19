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