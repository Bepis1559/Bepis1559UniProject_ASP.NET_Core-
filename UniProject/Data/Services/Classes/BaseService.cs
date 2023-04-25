using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniProject.Data.Classes;
using UniProject.Data.Services.Interfaces;

namespace UniProject.Data.Services.Classes
{
	public abstract class BaseService<T> : IService<T> where T : class
	{
		private readonly ApplicationDbContext _dbContext;

		protected BaseService(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Task<int> Save() => _dbContext.SaveChangesAsync();

		public async Task<List<T>> GetAllAsync() => await _dbContext.Set<T>().ToListAsync();

		public async Task<T> GetByIdAsync(string id) => await _dbContext.Set<T>().FindAsync(id);

		

		public async Task<T> CreateAsync(T entity)
		{
			_dbContext.Set<T>().Add(entity);
			await Save();
			return entity;
		}

		public async Task<T> DeleteByIdAsync(string id)
		{
			T entity = await GetByIdAsync(id);
			if (entity != null)
			{
				_dbContext.Set<T>().Remove(entity);
				await Save();
			}
			return entity;
		}

		public async Task<T> UpdateAsync(T entity)
		{
			_dbContext.Set<T>().Update(entity);
			await Save();
			return entity;
		}
	}
}
