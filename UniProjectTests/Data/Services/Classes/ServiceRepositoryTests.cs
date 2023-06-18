using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using UniProject.Data.Classes;
using UniProject.Data.Services.Classes;
using UniProject.Models.Classes;
using UniProject.Models.Interfaces;
using UniProjectTests.Data.Services.Classes;

namespace UniProject.Data.Services.Classes.Tests
{
    [TestClass()]
    public class ServiceRepositoryTests
    {
        private DbContextOptions<ApplicationDbContext>? _options;
        private ApplicationDbContext? _dbContext;
        private ServiceRepository _serviceRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _dbContext = new ApplicationDbContext(_options);
            _serviceRepository = new ServiceRepository(_dbContext);
        }

        [TestCleanup]
        public void TestCleanup()
        {
           
            _dbContext?.Dispose();
        }


        // mark method as a parameter one
        [DataTestMethod]
        // pass diff values as parameters
        [DataRow(typeof(BodyweightTracker))]
        [DataRow(typeof(CalorieTracker))]
        [DataRow(typeof(Challenge))]
        [DataRow(typeof(Exercise))]
        //[DataRow(typeof(Exercise_Workout))]
        [DataRow(typeof(Meal))]
        [DataRow(typeof(MealPlan))]
        [DataRow(typeof(User))]
        [DataRow(typeof(WaterIntake))]
        [DataRow(typeof(Workout))]
        [DataRow(typeof(WorkoutPlan))]
        [DataRow(typeof(WorkoutSchedule))]

        public async Task CreateAsync_ShouldCreateEntity(Type entityType) 
        {
            // Arrange
            dynamic? entity = Activator.CreateInstance(entityType) ;

            // Act
            dynamic serviceCreatedEntity = await _serviceRepository.CreateAsync(entity) ;

            // Assert
            Assert.AreEqual(entity, serviceCreatedEntity);
        }



    }
}
