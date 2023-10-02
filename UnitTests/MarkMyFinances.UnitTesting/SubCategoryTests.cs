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
	public class SubCategoryServiceTests
	{
		//DI Classes
		private Mock<IUnitOfWork> _unitOfWork;
		private Mock<IMapper> _mapper;
		private IServices<SubCategoryDto> _services;

		//obj required for setup
		private Mock<SubCategory> _subCategory;
		private Mock<SubCategoryDto> _subCategoryDto;

		public SubCategoryServiceTests()
		{
			_unitOfWork = new Mock<IUnitOfWork>();
			_mapper = new Mock<IMapper>();
			_services = new SubCategoryService(_unitOfWork.Object, _mapper.Object);

			Setup();
		}

		[SetUp]
		public void Setup()
		{
			_subCategory = new Mock<SubCategory>();
			_subCategoryDto = new Mock<SubCategoryDto>();
		}

		[Test]
		public async Task CreateSubCategory_ReceivesCorrectInput_ReturnsTrue()
		{
			_unitOfWork.Setup(sub => sub.SubCategoryRepository.CreateAsync(It.IsAny<SubCategory>())).ReturnsAsync(true);

			var result = await _services.AddAsync(new Mock<SubCategoryDto>().Object);

			Assert.That(result, Is.True);
		}

		// this will be an exception
		[Test]
		public async Task CreatesSubCategory_ReceivesWrongEntity_ReturnsFalse()
		{
			_unitOfWork.Setup(sub => sub.SubCategoryRepository.CreateAsync(It.IsAny<SubCategory>())).ReturnsAsync(false);

			var result = await _services.AddAsync(new Mock<SubCategoryDto>().Object);

			Assert.That(result, Is.False);
		}

		[Test]
		public async Task EditsSubCategory_ReceivesCorrectEntity_ReturnsTrue()
		{
			_subCategoryDto.Object.Name = "NEW OBJ";
			_unitOfWork.Setup(sub => sub.SubCategoryRepository.UpdateAsync(It.IsAny<SubCategory>())).ReturnsAsync(true);

			var result = await _services.EditAsync(_subCategoryDto.Object);

			Assert.That(result, Is.True);
		}

		// this will be a exception
		[Test]
		public async Task EditsSubCategory_ReceivesWrongEntity_ReturnsFalse()
		{
			_subCategoryDto.Object.Name = "NEW OBJ";
			_unitOfWork.Setup(sub => sub.SubCategoryRepository.UpdateAsync(It.IsAny<SubCategory>())).ReturnsAsync(false);

			var result = await _services.EditAsync(_subCategoryDto.Object);

			Assert.That(result, Is.EqualTo(false));
		}

		[Test]
		public async Task RemovesSubCategory_ReceiveExistingEntity_ReturnsTrue()
		{
			int id = 1;
			_unitOfWork.Setup(sub => sub.SubCategoryRepository.GetByIdAsync(id)).ReturnsAsync(new SubCategory() { Id = id });
			_unitOfWork.Setup(sub => sub.SubCategoryRepository.DeleteAsync(It.IsAny<SubCategory>())).ReturnsAsync(true);
			var result = await _services.RemoveAsync(1);

			Assert.That(result, Is.EqualTo(true));
		}

		[Test]
		public void GetSubCategoryById_ReceivesCorrectId_ReturnsSubCategory()
		{
			int id = 1;
			_unitOfWork.Setup(sub => sub.SubCategoryRepository.GetByIdAsync(id)).ReturnsAsync(_subCategory.Object);

			var result = _services.GetByID(id);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Id, Is.EqualTo(id));
		}
	}
}