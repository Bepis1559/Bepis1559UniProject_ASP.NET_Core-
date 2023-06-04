using Microsoft.EntityFrameworkCore;
using UniProject.Data.Classes;
using UniProject.Data.Services.Interfaces;
using UniProject.Models.Classes;
using UniProject.Models.Interfaces;

namespace UniProject.Data.Services.Classes
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ServiceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public Task<int> Save() => _dbContext.SaveChangesAsync();

        public async Task<List<T>> GetAllAsync<T>() where T : class, IId => await _dbContext.Set<T>().ToListAsync();

       

        public async Task<T> GetByIdAsync<T>(string id) where T : class,IId
        {
            var result = await _dbContext.Set<T>().FindAsync(id);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new NullReferenceException("Tried to access entity by id but got null");
            }
           

        }

        public async Task<T> GetByNameAsync<T>(string name) where T : class, IName {
           var result =  await _dbContext.Set<T>().Where(entity => entity.Name == name).FirstOrDefaultAsync();
            if(result  != null)
            {
                return result;
            }
            else
            {
                throw new NullReferenceException("Tried to access entity by name but got null");
            }
           


        }
        public async Task<T> CreateAsync<T>(T entity) where T : class,IId
        {
            _dbContext.Set<T>().Add(entity);
            await Save();
            return entity;
        }

        public async Task<T> DeleteByIdAsync<T>(string id) where T : class,IId
        {
            T entity = await GetByIdAsync<T>(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await Save();
                return entity;
            }
            throw new NullReferenceException("Tried to delete entity by id but got null");

        }

        public async Task<List<T>> DeleteAllAsync<T>(List<T> entitiesToDelete) where T : class, IId
        {

            entitiesToDelete.Clear();
            await Save();
            return entitiesToDelete;
        }

        public async Task<T> UpdateAsync<T>(T entity) where T : class,IId
        {
            if(entity != null)
            {
                _dbContext.Update(entity);
                await Save();
                return entity;
            }
            throw new NullReferenceException("Tried to update entity by id but got null");


        }

       
    }
}
