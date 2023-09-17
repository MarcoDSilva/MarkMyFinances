using MarkMyFinance.Persistance.Repository.Interfaces;
using MarkMyFinance.Domain.Entities;

namespace MarkMyFinance.Persistance.Repository
{
	public class InvestmentRepository : IInvestmentRepository
	{
		public Task<bool> CreateAsync(Investment entity)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteAsync(Investment entity)
		{
			throw new NotImplementedException();
		}

		public Task<List<Investment>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Investment?> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Investment>> GetByNameAsync(string name)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdateAsync(Investment entity)
		{
			throw new NotImplementedException();
		}
	}
}
