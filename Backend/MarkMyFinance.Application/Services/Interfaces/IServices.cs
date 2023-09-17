using MarkMyFinance.Domain.Entities;

namespace MarkMyFinance.Application.Services.Interfaces
{
	public interface IServices<T> where T : class
	{
		Task<List<T>> GetAllAsync();
		Task<bool> AddAsync(T entity);
		Task<bool> RemoveAsync(T entity);
		Task<bool> EditAsync(T entity);
		Task<T?> GetByID(int id);
	}
}
