using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniProject.Models.Classes;

namespace UniProject.Data.Classes
{
    public class ApplicationDbContext : IdentityDbContext<User>
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

		//public DbSet<User> Users { get; set; }
		public DbSet<MealPlan> MealPlans { get; set; }
		public DbSet<Meal> Meals { get; set; }
		public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
		public DbSet<Workout> Workouts { get; set; }
		public DbSet<Exercise> Exercises { get; set; }
		public DbSet<Exercise_Workout> Exercise_Workouts { get; set; }
		public DbSet<WaterIntake> WaterIntakes { get; set; }
		public DbSet<CalorieTracker> CalorieTrackers { get; set; }
		public DbSet<Challenge> Challenges { get; set; }
		public DbSet<BodyweightTracker> BodyweightTrackers { get; set; }
		public DbSet<WorkoutSchedule> WorkoutSchedules { get; set; }
		public DbSet<DeadliftTracker> DeadliftTrackers { get; set;}
		public DbSet<BenchTracker> BenchTrackers { get; set;}
		public DbSet<SquatTracker> SquatTrackers { get; set;}

		

	}
}
