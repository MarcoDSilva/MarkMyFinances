using MarkMyFinance.Application.Repository.Interfaces;
using MarkMyFinance.Domain.Entities;
using MarkMyFinance.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace MarkMyFinance.Application.Repository
{
	public class SubCategoryRepository : ISubCategoryRepository
	{
		private readonly FinancesDBContext _dbContext;

		public SubCategoryRepository(FinancesDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<bool> CreateAsync(SubCategory entity)
		{
			var inserted = await _dbContext.SubCategories.AddAsync(entity);
			return await SaveDb();

		}

		public async Task<bool> DeleteAsync(SubCategory entity)
		{
			var deleted = _dbContext.SubCategories.Remove(entity);
			return await SaveDb();
		}

		public async Task<List<SubCategory>> GetAllAsync()
		{
			return await _dbContext.SubCategories.ToListAsync();
		}

		public async Task<SubCategory?> GetByIdAsync(int id)
		{
			var subCategories = await _dbContext.SubCategories.ToListAsync();
			return subCategories.Where(ct => ct.Id == id).FirstOrDefault();
		}

		public async Task<List<SubCategory>> GetByNameAsync(string name)
		{
			var subCategories = await _dbContext.SubCategories.ToListAsync();
			return subCategories.Where(ct => ct.Name.ToLower().Equals(name.ToLower())).ToList();
		}

		public async Task<bool> UpdateAsync(SubCategory entity)
		{
			_dbContext.SubCategories.Update(entity);
			return await SaveDb();
		}

		private async Task<bool> SaveDb()
		{
			int save = await _dbContext.SaveChangesAsync();
			return save > 0;
		}
	}
}
