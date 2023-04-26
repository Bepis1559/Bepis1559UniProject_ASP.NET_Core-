
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







//builder.Services.AddScoped<MealPlansService>();
//builder.Services.AddScoped<UsersService>();
//builder.Services.AddScoped<BodyweightTrackersService>();
//builder.Services.AddScoped<CalorieTrackerService>();
//builder.Services.AddScoped<ExercisesService>();
//builder.Services.AddScoped<MealsService>();
//builder.Services.AddScoped<MealPlansService>();
//builder.Services.AddScoped<ProgressTrackingsService>();
//builder.Services.AddScoped<WaterIntakesService>();
//builder.Services.AddScoped<WorkoutsService>();
//builder.Services.AddScoped<WorkoutPlansService>();
//builder.Services.AddScoped<WorkoutSchedulesService>();


static void AddServices(IServiceCollection services, params Type[] types)
{
    foreach (var type in types)
    {
        services.AddScoped(type);
    }
}

AddServices(builder.Services,
    typeof(MealPlansService),
    typeof(UsersService),
    typeof(BodyweightTrackersService),
    typeof(CalorieTrackerService),
    typeof(ExercisesService),
    typeof(MealsService),
    typeof(MealPlansService),
    typeof(ProgressTrackingsService),
    typeof(WaterIntakesService),
    typeof(WorkoutsService),
    typeof(WorkoutPlansService),
    typeof(WorkoutSchedulesService));







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



