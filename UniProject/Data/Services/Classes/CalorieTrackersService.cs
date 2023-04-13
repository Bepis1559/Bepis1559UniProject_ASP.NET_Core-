using Microsoft.EntityFrameworkCore;
using UniProject.Data.Classes;
using UniProject.Data.Services.Interfaces;
using UniProject.Models.Classes;

namespace UniProject.Data.Services.Classes
{
	public class CalorieTrackerService : BaseService<CalorieTracker>
	{
		public CalorieTrackerService(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
