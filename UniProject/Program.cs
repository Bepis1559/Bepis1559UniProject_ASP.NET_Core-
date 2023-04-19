
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using UniProject.Data.Classes;
using UniProject.Data.Services;
using UniProject.Data.Services.Classes;
using UniProject.Data.Services.Interfaces;
using UniProject.Models.Classes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
	.AddEntityFrameworkStores<ApplicationDbContext>();






void AddScopedService<TEntity, TService>()
	where TEntity : class
	where TService : class, IService<TEntity>
{
	builder?.Services.AddScoped<IService<TEntity>, TService>();
}

AddScopedService<User,UsersService>();
AddScopedService<BodyweightTracker,BodyweightTrackersService>();
AddScopedService<CalorieTracker,CalorieTrackerService>();
AddScopedService<Challenge,ChallengesService>();
AddScopedService<Exercise,ExercisesService>();
AddScopedService<Meal,MealsService>();
AddScopedService<MealPlan,MealPlansService>();
AddScopedService<ProgressTracking,ProgressTrackingsService>();
AddScopedService<WaterIntake,WaterIntakesService>();
AddScopedService<Workout,WorkoutsService>();
AddScopedService<WorkoutPlan,WorkoutPlansService>();
AddScopedService<WorkoutSchedule,WorkoutSchedulesService>();




builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();




app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();



