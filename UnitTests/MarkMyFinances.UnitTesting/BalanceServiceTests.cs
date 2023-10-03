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
	public class BalanceServiceTests
	{
		//DI Classes
		private Mock<IUnitOfWork> _unitOfWork;
		private Mock<IMapper> _mapper;
		private IServices<BalanceDto> _services;

		// obj required for setup
		private Mock<Balance> _balance;
		private Mock<BalanceDto> _balanceDto;

		public BalanceServiceTests()
		{
			_unitOfWork = new Mock<IUnitOfWork>();
			_mapper = new Mock<IMapper>();
			_services = new BalanceService(_mapper.Object, _unitOfWork.Object);

			Setup();
		}


		[SetUp]
		public void Setup()
		{
			_balance = new Mock<Balance>();
			_balanceDto = new Mock<BalanceDto>();
		}

		[Test]
		public async Task CreateBalance_ReceivesCorrectInput_ReturnsTrue()
		{
			_unitOfWork.Setup(bal => bal.BalanceRepository.CreateAsync(It.IsAny<Balance>())).ReturnsAsync(true);
			var result = await _services.AddAsync(_balanceDto.Object);

			Assert.That(result, Is.True);
		}

		// this will be an exception
		[Test]
		public async Task CreatesBalance_ReceivesWrongEntity_ReturnsFalse()
		{
			_unitOfWork.Setup(bal => bal.BalanceRepository.CreateAsync(It.IsAny<Balance>())).ReturnsAsync(false);

			var result = await _services.AddAsync(new Mock<BalanceDto>().Object);

			Assert.That(result, Is.False);
		}

		[Test]
		public async Task EditsBalance_ReceivesCorrectEntity_ReturnsTrue()
		{
			_balanceDto.Object.InitialBalance = 122;
			_unitOfWork.Setup(bal => bal.BalanceRepository.UpdateAsync(It.IsAny<Balance>())).ReturnsAsync(true);

			var result = await _services.EditAsync(_balanceDto.Object);

			Assert.That(result, Is.True);
		}

		// this will be a exception
		[Test]
		public async Task EditsBalance_ReceivesWrongEntity_ReturnsFalse()
		{
			_balanceDto.Object.InitialBalance = 122;
			_unitOfWork.Setup(bal => bal.BalanceRepository.UpdateAsync(It.IsAny<Balance>())).ReturnsAsync(false);

			var result = await _services.EditAsync(_balanceDto.Object);

			Assert.That(result, Is.EqualTo(false));
		}

		[Test]
		public async Task RemovesBalance_ReceiveExistingEntity_ReturnsTrue()
		{
			int id = 1;
			_unitOfWork.Setup(bal => bal.BalanceRepository.GetByIdAsync(id)).ReturnsAsync(new Balance() { Id = id });
			_unitOfWork.Setup(bal => bal.BalanceRepository.DeleteAsync(It.IsAny<Balance>())).ReturnsAsync(true);
			var result = await _services.RemoveAsync(1);

			Assert.That(result, Is.EqualTo(true));
		}

		[Test]
		public void GetBalanceById_ReceivesCorrectId_ReturnsCategory()
		{
			int id = 1;
			_balance.Object.Id = id;
			_unitOfWork.Setup(bal => bal.BalanceRepository.GetByIdAsync(id)).ReturnsAsync(_balance.Object);

			var result = _services.GetByID(id);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Id, Is.EqualTo(id));
		}
	}
}