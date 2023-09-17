namespace MarkMyFinance.Persistance.Repository.Interfaces
{
	public interface IUnitOfWork
	{
		ICategoryRepository CategoryRepository { get; }
		ISubCategoryRepository SubCategoryRepository { get; }
		IExpensesRepository ExpensesRepository { get; }
		IIncomeRepository IncomeRepository { get; }
		IInvestmentRepository InvestmentRepository { get; }
	}
}