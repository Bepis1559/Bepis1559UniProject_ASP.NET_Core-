using Microsoft.AspNetCore.Identity;

namespace UniProject.Models.Classes
{
    public class User : IdentityUser
    {
        // Id , Email and Role are added by IdentityUser
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte[]? ProfileImage { get; set; }







        // sets a hashed password for the current instance of User, and returns a completed task.
        public async Task SetPasswordAsync(string password)
        {
            //  creates a new instance of PasswordHasher with the type parameter User.
            var hasher = new PasswordHasher<User>();

            // generates a hashed password for the current instance
            // of User and sets it as the value of the PasswordHash property.
            PasswordHash = hasher.HashPassword(this, password);

            //returns a completed task with the result 0
            // used to satisfy the return type of the SetPassword method, which is Task.
            await Task.FromResult(0);
        }

        public async Task<bool> CheckPasswordAsync(string password)
        {
            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(this, PasswordHash, password);
            return await Task.FromResult(result == PasswordVerificationResult.Success);
        }

        // relations

        public ProgressTracking? ProgressTracking { get; set; }
        public ICollection<MealPlan> MealPlans { get; set; } = new List<MealPlan>();
        public ICollection<WorkoutPlan> WorkoutPlans { get; set; } = new List<WorkoutPlan>();
        public ICollection<Challenge> Challenges { get; set; } = new List<Challenge>();
        public ICollection<WaterIntake> WaterIntakes { get; set; } = new List<WaterIntake>();
        public ICollection<CalorieTracker> CalorieTrackers { get; set; } = new List<CalorieTracker>();
        public ICollection<BodyweightTracker> BodyweightTrackers { get; set; } = new List<BodyweightTracker>();
        public ICollection<WorkoutSchedule> WorkoutSchedules { get; set; } = new List<WorkoutSchedule>();

        
    }
}
