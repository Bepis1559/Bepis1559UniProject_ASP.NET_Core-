using Microsoft.EntityFrameworkCore;
using UniProject.Data.Classes;
using UniProject.Data.Services.Interfaces;
using UniProject.Models.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniProject.Data.Services.Classes
{
	public class MealPlansService : BaseService<MealPlan>
	{
        private readonly ApplicationDbContext _dbContext;
        public MealPlansService(ApplicationDbContext dbContext) : base(dbContext)
		{
            _dbContext = dbContext;
		}

        public async Task<MealPlan> GetByNameAsync(string name) => await _dbContext.MealPlans.Where(entity => entity.Name == name).FirstOrDefaultAsync();
    }
}
