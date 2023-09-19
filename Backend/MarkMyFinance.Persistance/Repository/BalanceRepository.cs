using MarkMyFinance.Domain.Entities;
using MarkMyFinance.Domain.Interfaces;
using MarkMyFinance.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace MarkMyFinance.Persistance.Repository
{
	public class BalanceRepository : IRepository<Balance>
	{
		private readonly FinancesDBContext _dbContext;
		public BalanceRepository(FinancesDBContext dBContext)
		{
			_dbContext = dBContext;
		}

		public async Task<bool> CreateAsync(Balance entity)
		{
			var insertedId = await _dbContext.Balance.AddAsync(entity);
			return await SaveDb();
		}

		public async Task<bool> DeleteAsync(Balance entity)
		{
			var deleted = _dbContext.Balance.Remove(entity);
			return await SaveDb();
		}

		public async Task<List<Balance>> GetAllAsync()
		{
			var balance = await _dbContext.Balance.ToListAsync();
			return balance;
		}

		public async Task<Balance?> GetByIdAsync(int id)
		{
			var balance = await _dbContext.Balance.ToListAsync();
			return balance.Where(ct => ct.Id == id).FirstOrDefault();
		}

		public Task<List<Balance>> GetByNameAsync(string name)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> UpdateAsync(Balance entity)
		{
			_dbContext.Balance.Update(entity);
			return await SaveDb();
		}

		private async Task<bool> SaveDb()
		{
			int save = await _dbContext.SaveChangesAsync();
			return save > 0;
		}
	}
}
