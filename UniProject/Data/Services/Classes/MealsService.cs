using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniProject.Data.Classes;
using UniProject.Data.Services.Interfaces;
using UniProject.Models.Classes;

namespace UniProject.Data.Services.Classes
{
	public class MealsService : BaseService<Meal>
	{
		public MealsService(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
