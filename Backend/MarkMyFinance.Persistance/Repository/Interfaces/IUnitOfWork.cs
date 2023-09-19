using MarkMyFinance.Domain.Entities;
using MarkMyFinance.Domain.Interfaces;

namespace MarkMyFinance.Persistance.Repository.Interfaces
{
	public interface IUnitOfWork
	{
		IRepository<Category> CategoryRepository { get; }
		IRepository<SubCategory> SubCategoryRepository { get; }
		IRepository<Expense> ExpensesRepository { get; }
		IRepository<Income> IncomeRepository { get; }
		IRepository<Investment> InvestmentRepository { get; }
		IRepository<Balance> BalanceRepository { get; }
	}
}