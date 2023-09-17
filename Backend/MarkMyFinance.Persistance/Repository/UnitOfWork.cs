using MarkMyFinance.Persistance.Repository.Interfaces;

namespace MarkMyFinance.Persistance.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }

        public ISubCategoryRepository SubCategoryRepository { get; }

        public IExpensesRepository ExpensesRepository { get; }

        public IIncomeRepository IncomeRepository { get; }

        public IInvestmentRepository InvestmentRepository { get; }

        public UnitOfWork(
                ICategoryRepository categoryRepository,
                ISubCategoryRepository subCategoryRepository,
                IExpensesRepository expensesRepository,
                IIncomeRepository incomeRepository,
                IInvestmentRepository investmentRepository
            )
        {
            CategoryRepository = categoryRepository;
            SubCategoryRepository = subCategoryRepository;
            ExpensesRepository = expensesRepository;
            IncomeRepository = incomeRepository;
            InvestmentRepository = investmentRepository;
        }
    }
}
