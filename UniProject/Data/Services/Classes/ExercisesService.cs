using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniProject.Data.Classes;
using UniProject.Data.Services.Classes;
using UniProject.Data.Services.Interfaces;
using UniProject.Models;
using UniProject.Models.Classes;

namespace UniProject.Data.Services
{
	public class ExercisesService : BaseService<Exercise>
	{
		public ExercisesService(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
