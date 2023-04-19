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

        public MealPlansService(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
