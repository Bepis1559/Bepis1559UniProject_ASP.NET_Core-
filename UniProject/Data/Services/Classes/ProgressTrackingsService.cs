using Microsoft.EntityFrameworkCore;
using UniProject.Data.Classes;
using UniProject.Data.Services.Interfaces;
using UniProject.Models.Classes;

namespace UniProject.Data.Services.Classes
{
	public class ProgressTrackingsService : BaseService<ProgressTracking>
	{
		public ProgressTrackingsService(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
