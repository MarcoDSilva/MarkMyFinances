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
	public class IncomeServiceTests
	{
		// DI classes
		private Mock<IUnitOfWork> _unitOfWork;
		private Mock<IMapper> _mapper;
		private IServices<IncomeDto> _incomeService;

		// objects required for test
		private Mock<Income> _income;
		private Mock<IncomeDto> _incomeDto;

		public IncomeServiceTests()
		{
			_unitOfWork = new Mock<IUnitOfWork>();
			_mapper = new Mock<IMapper>();
			_incomeService = new IncomeService(_unitOfWork.Object, _mapper.Object);

			Setup();
		}

		[SetUp]
		public void Setup()
		{
			_income = new Mock<Income>();
			_incomeDto = new Mock<IncomeDto>();
		}

		[Test]
		public async Task CreateIncome_ReceivesCorrectEntity_ReturnsTrue()
		{
			_incomeDto.Object.Id = 1;

			_unitOfWork.Setup(inc => inc.IncomeRepository.CreateAsync(It.IsAny<Income>())).ReturnsAsync(true);

			var result = await _incomeService.AddAsync(_incomeDto.Object);

			Assert.That(result, Is.EqualTo(true));
		}

		[Test]
		public async Task CreateIncome_WrongInput_ReturnsFalse()
		{
			_incomeDto.Object.Id = -1;

			_unitOfWork.Setup(inc => inc.IncomeRepository.CreateAsync(It.IsAny<Income>())).ReturnsAsync(false);

			var result = await _incomeService.AddAsync(_incomeDto.Object);

			Assert.That(result, Is.EqualTo(false));
		}

		[Test]
		public async Task EditIncome_ReceivesCorrectEntity_ReturnsTrue()
		{
			_incomeDto.Object.Value = 200;

			_unitOfWork.Setup(inc => inc.IncomeRepository.UpdateAsync(It.IsAny<Income>())).ReturnsAsync(true);

			var result = await _incomeService.EditAsync(_incomeDto.Object);

			Assert.That(result, Is.EqualTo(true));
		}

		[Test]
		public async Task EditIncome_WrongEntity_ReturnsFalse()
		{
			_unitOfWork.Setup(inc => inc.IncomeRepository.UpdateAsync(It.IsAny<Income>())).ReturnsAsync(false);

			var result = await _incomeService.EditAsync(_incomeDto.Object);

			Assert.That(result, Is.EqualTo(false));
		}

		[Test]
		public async Task RemovesIncome_ReceiveExistingEntity_ReturnsTrue()
		{
			int id = 1;
			_unitOfWork.Setup(inc => inc.IncomeRepository.GetByIdAsync(id)).ReturnsAsync(new Income() { Id = id });
			_unitOfWork.Setup(inc => inc.IncomeRepository.DeleteAsync(It.IsAny<Income>())).ReturnsAsync(true);
			var result = await _incomeService.RemoveAsync(1);

			Assert.That(result, Is.EqualTo(true));
		}

		[Test]
		public void GetIncomeById_ReceivesCorrectId_ReturnsIncome()
		{
			int incomeId = 1;
			_unitOfWork.Setup(inc => inc.IncomeRepository.GetByIdAsync(incomeId)).ReturnsAsync(_income.Object);

			var result =  _incomeService.GetByID(incomeId);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Id, Is.EqualTo(incomeId));
		}
	}
}