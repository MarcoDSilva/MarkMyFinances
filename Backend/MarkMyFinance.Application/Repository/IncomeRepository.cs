using MarkMyFinance.Application.Repository.Interfaces;
using MarkMyFinance.Domain.Entities;
using MarkMyFinance.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace MarkMyFinance.Application.Repository
{

	public class IncomeRepository : IIncomeRepository
	{
		private readonly FinancesDBContext _dbContext;

		public IncomeRepository(FinancesDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<bool> CreateAsync(Income entity)
		{
			var inserted = await _dbContext.Income.AddAsync(entity);
			return await SaveDb();
		}

		public async Task<bool> DeleteAsync(Income entity)
		{
			var deleted = _dbContext.Income.Remove(entity);
			return await SaveDb();
		}

		public async Task<List<Income>> GetAllAsync()
		{
			var incomes = await _dbContext.Income.ToListAsync();
			return incomes;
		}

		public async Task<Income?> GetByIdAsync(int id)
		{
			var incomes = await _dbContext.Income.ToListAsync();
			return incomes.FirstOrDefault(inc => inc.Id == id);
		}

		public async Task<List<Income>> GetByNameAsync(string name)
		{
			var incomes = await _dbContext.Income.ToListAsync();
			return incomes.Where(inc => inc.Description.ToLower().Equals(name?.ToLower())).ToList();
		}

		public async Task<bool> UpdateAsync(Income entity)
		{
			_dbContext.Income.Update(entity);
			return await SaveDb();
		}

		private async Task<bool> SaveDb()
		{
			int save = await _dbContext.SaveChangesAsync();
			return save > 0;
		}
	}

}