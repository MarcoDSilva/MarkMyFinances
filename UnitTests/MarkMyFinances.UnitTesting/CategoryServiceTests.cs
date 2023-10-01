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
	public class CategoryServiceTest
	{
		// DI Classes
		private Mock<IUnitOfWork> _unitOfWork;
		private Mock<IMapper> _mapper;
		private IServices<CategoryDto> _categoryService;

		// obj required for setup
		private Mock<Category> _category;
		private Mock<CategoryDto> _categoryDto;

		public CategoryServiceTest()
		{
			_unitOfWork = new Mock<IUnitOfWork>();
			_mapper = new Mock<IMapper>();
			_categoryService = new CategoryService(_unitOfWork.Object, _mapper.Object);

			Setup();
		}

		[SetUp]
		public void Setup()
		{
			_category = new Mock<Category>();
			_categoryDto = new Mock<CategoryDto>();
		}

		[Test]
		public async Task CreateCategory_ReceivesCorrectInput_ReturnsTrue()
		{
			_unitOfWork.Setup(cat => cat.CategoryRepository.CreateAsync(It.IsAny<Category>())).ReturnsAsync(true);
			var result = await _categoryService.AddAsync(_categoryDto.Object);

			Assert.That(result, Is.True);
		}

		// this will be an exception
		[Test]
		public async Task CreatesCategory_ReceivesWrongEntity_ReturnsFalse()
		{
			_unitOfWork.Setup(cat => cat.CategoryRepository.CreateAsync(It.IsAny<Category>())).ReturnsAsync(false);

			var result = await _categoryService.AddAsync(new Mock<CategoryDto>().Object);

			Assert.That(result, Is.False);
		}

		[Test]
		public async Task EditsCategory_ReceivesCorrectEntity_ReturnsTrue()
		{
			_categoryDto.Object.Name = "NEW OBJ";
			_unitOfWork.Setup(cat => cat.CategoryRepository.UpdateAsync(It.IsAny<Category>())).ReturnsAsync(true);

			var result = await _categoryService.EditAsync(_categoryDto.Object);

			Assert.That(result, Is.True);
		}

		// this will be a exception
		[Test]
		public async Task EditsCategory_ReceivesWrongEntity_ReturnsFalse()
		{
			_categoryDto.Object.Name = "NEW OBJ";
			_unitOfWork.Setup(cat => cat.CategoryRepository.UpdateAsync(It.IsAny<Category>())).ReturnsAsync(false);

			var result = await _categoryService.EditAsync(_categoryDto.Object);

			Assert.That(result, Is.EqualTo(false));
		}


		[Test]
		public async Task RemovesCategory_ReceiveExistingEntity_ReturnsTrue()
		{
			int id = 1;
			_unitOfWork.Setup(cat => cat.CategoryRepository.GetByIdAsync(id)).ReturnsAsync(new Category() { Id = id});
			_unitOfWork.Setup(cat => cat.CategoryRepository.DeleteAsync(It.IsAny<Category>())).ReturnsAsync(true);
			var result = await _categoryService.RemoveAsync(1);

			Assert.That(result, Is.EqualTo(true));
		}

		[Test]
		public void GetExpenseById_ReceivesCorrectId_ReturnsExpense()
		{
			int id = 1;
			_unitOfWork.Setup(cat => cat.CategoryRepository.GetByIdAsync(id)).ReturnsAsync(_category.Object);

			var result = _categoryService.GetByID(id);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Id, Is.EqualTo(id));
		}


	}
}