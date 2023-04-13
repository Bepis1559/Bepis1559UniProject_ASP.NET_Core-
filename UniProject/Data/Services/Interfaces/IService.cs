namespace UniProject.Data.Services.Interfaces
{
    public interface IService<T>
    {
        public Task<int> Save();
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteByIdAsync(string id);
    }
}
