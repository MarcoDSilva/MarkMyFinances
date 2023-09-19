using MarkMyFinance.Domain.Entities;
using MarkMyFinance.Domain.Interfaces;
using MarkMyFinance.Persistance.Repository.Interfaces;

namespace MarkMyFinance.Persistance.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		public IRepository<Category> CategoryRepository { get; }

		public IRepository<SubCategory> SubCategoryRepository { get; }

		public IRepository<Expense> ExpensesRepository { get; }

		public IRepository<Income> IncomeRepository { get; }

		public IRepository<Investment> InvestmentRepository { get; }

		public IRepository<Balance> BalanceRepository { get; }

		public UnitOfWork(
				IRepository<Category> categoryRepository,
				IRepository<SubCategory> subCategoryRepository,
				IRepository<Expense> expensesRepository,
				IRepository<Income> incomeRepository,
				IRepository<Investment> investmentRepository,
				IRepository<Balance> balanceRepository
			)
		{
			CategoryRepository = categoryRepository;
			SubCategoryRepository = subCategoryRepository;
			ExpensesRepository = expensesRepository;
			IncomeRepository = incomeRepository;
			InvestmentRepository = investmentRepository;
			BalanceRepository = balanceRepository;
		}
	}
}
