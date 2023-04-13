using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniProject.Data.Classes;
using UniProject.Data.Services.Interfaces;
using UniProject.Models.Classes;

namespace UniProject.Data.Services.Classes
{
	public class WorkoutSchedulesService : BaseService<WorkoutSchedule>
	{
		public WorkoutSchedulesService(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
