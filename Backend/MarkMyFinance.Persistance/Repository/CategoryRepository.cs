using MarkMyFinance.Domain.Entities;
using MarkMyFinance.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using MarkMyFinance.Domain.Interfaces;

namespace MarkMyFinance.Persistance.Repository
{
	public class CategoryRepository : IRepository<Category>
	{
		private readonly FinancesDBContext _dbContext;
		public CategoryRepository(FinancesDBContext dBContext)
		{
			_dbContext = dBContext;
		}

		public async Task<bool> CreateAsync(Category entity)
		{
			var insertedId = await _dbContext.Categories.AddAsync(entity);
			return await SaveDb();
		}

		public async Task<bool> DeleteAsync(Category entity)
		{
			var deleted = _dbContext.Categories.Remove(entity);
			return await SaveDb();
		}

		public async Task<List<Category>> GetAllAsync()
		{
			var categories = await _dbContext.Categories.ToListAsync();
			return categories;
		}

		public async Task<Category?> GetByIdAsync(int id)
		{
			var categories = await _dbContext.Categories.ToListAsync();
			return categories.Where(ct => ct.Id == id).FirstOrDefault();
		}

		public async Task<List<Category>> GetByNameAsync(string name)
		{
			var categories = await _dbContext.Categories.ToListAsync();
			return categories.Where(cat => cat.Name.ToLower().Equals(name.ToLower())).ToList();
		}

		public async Task<bool> UpdateAsync(Category entity)
		{
			_dbContext.Categories.Update(entity);
			return await SaveDb();
		}

		private async Task<bool> SaveDb()
		{
			int save = await _dbContext.SaveChangesAsync();
			return save > 0;
		}
	}
}
