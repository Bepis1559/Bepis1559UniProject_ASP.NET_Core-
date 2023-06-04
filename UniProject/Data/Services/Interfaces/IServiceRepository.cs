using Microsoft.EntityFrameworkCore;
using UniProject.Models.Interfaces;

namespace UniProject.Data.Services.Interfaces
{
    public interface IServiceRepository
    {
        public Task<int> Save();
        Task<List<T>> GetAllAsync<T>() where T : class, IId;
        Task<T> CreateAsync<T>(T entity) where T : class,IId;
        Task<T> UpdateAsync<T>(T entity) where T : class,IId;
        Task<T> DeleteByIdAsync<T>(string id) where T : class,IId;
        Task<T> GetByNameAsync<T>(string name) where T : class,IName;

        Task<List<T>> DeleteAllAsync<T>(List<T> entitiesToDelete) where T : class, IId;
    }
}
