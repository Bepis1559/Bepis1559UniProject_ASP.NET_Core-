using Microsoft.EntityFrameworkCore;
using UniProject.Data.Classes;
using UniProject.Data.Services.Interfaces;
using UniProject.Models.Classes;

namespace UniProject.Data.Services.Classes
{
	public class UsersService : BaseService<User>
	{
		public UsersService(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
