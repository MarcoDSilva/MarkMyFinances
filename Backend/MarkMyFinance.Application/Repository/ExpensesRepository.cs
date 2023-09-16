using MarkMyFinance.Application.Repository.Interfaces;
using MarkMyFinance.Domain.Entities;
using MarkMyFinance.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace MarkMyFinance.Application.Repository
{
	public class ExpensesRepository : IExpensesRepository
	{
		private readonly FinancesDBContext _dbContext;
		public ExpensesRepository(FinancesDBContext dBContext)
		{
			_dbContext = dBContext;
		}

		public async Task<bool> CreateAsync(Expense entity)
		{
			var inserted = await _dbContext.Expenses.AddAsync(entity);
			return await SaveDb();
		}

		public async Task<bool> DeleteAsync(Expense entity)
		{
			var deleted = _dbContext.Expenses.Remove(entity);
			return await SaveDb();
		}

		public async Task<List<Expense>> GetAllAsync()
		{
			var expenses = await _dbContext.Expenses.ToListAsync();
			return expenses;
		}

		public async Task<Expense?> GetByIdAsync(int id)
		{
			var expenses = await _dbContext.Expenses.ToListAsync();
			return expenses.Where(ex => ex.Id == id).FirstOrDefault();
		}

		public async Task<List<Expense>> GetByNameAsync(string name)
		{
			var expenses = await _dbContext.Expenses.ToListAsync();
			var expense = expenses.Where(exp => exp.Description.ToLower().Equals(name.ToLower())).ToList();
			return expense;
		}

		public async Task<bool> UpdateAsync(Expense entity)
		{
			_dbContext.Expenses.Update(entity);
			return await SaveDb();
		}
		private async Task<bool> SaveDb()
		{
			int save = await _dbContext.SaveChangesAsync();
			return save > 0;
		}
	}
}
