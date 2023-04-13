using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniProject.Data.Services.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniProject.Data.Classes;
using UniProject.Models.Classes;

namespace UniProject.Data.Services.Classes.Tests
{
	[TestClass()]
	public class UsersServiceTests
	{
		private DbContextOptions<ApplicationDbContext>? _options;
		private ApplicationDbContext? _dbContext;
		private UsersService _userService;

		static User CreateUser(string FirstName, string LastName) => new() { Id = Guid.NewGuid().ToString(), FirstName = FirstName, LastName = LastName };


		async Task InitializeUser(User user) => await _userService.CreateAsync(user);


		[TestInitialize]
		public void TestInitialize()
		{
			_options = new DbContextOptionsBuilder<ApplicationDbContext>()
				.UseInMemoryDatabase(databaseName: "TestDb")
				.Options;

			_dbContext = new ApplicationDbContext(_options);
			_userService = new UsersService(_dbContext);
		}

		[TestCleanup]
		public void TestCleanup() 
		{
			_dbContext?.Users.RemoveRange(_dbContext.Users);
			_dbContext?.SaveChanges();
			_dbContext?.Dispose();
		}

		[TestMethod()]
		public async Task CreateAsync_ShouldCreateUser()
		{
			// Arrange
			var user = new User();

			// Act
			var result = await _userService.CreateAsync(user);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(user, result);
		}

		[TestMethod()]
		public async Task GetAllAsync_ShouldGetAllUsers()
		{
			// Arrange

			

			User user1 = CreateUser("John", "Doe");
			User user2 = CreateUser("Jane","Moe");
			User user3 = CreateUser("Bob", "Smith");




			await InitializeUser(user1);
			await InitializeUser(user2);
			await InitializeUser(user3);

			

			// Act
			var result = await _userService.GetAllAsync();


			// assert
			Assert.IsNotNull(result);
			Assert.AreEqual(3, result.Count);

			void AssertIfTrue(User user) => Assert.IsTrue(result.Contains(user));

			AssertIfTrue(user1);
			AssertIfTrue(user2);
			AssertIfTrue(user3);

		}

		[TestMethod()]

		public async Task DeleteByIdAsync_ShouldDeleteUserById()
		{

			// arrange

			User user1 = CreateUser("John", "Doe");
			

			await InitializeUser(user1);
			

			// act
			
			var result = await _userService.DeleteByIdAsync(user1.Id);
			List<User> users = await _userService.GetAllAsync();

			// assert

			Assert.IsNotNull(result);
			Assert.IsFalse(users.Contains(user1));
			Assert.AreEqual(0,users.Count);
		}

		[TestMethod()]

		public async Task GetByIdAsync_ShouldGetUserById()
		{

			// arrange
			User user1 = CreateUser("Emily", "Dane");

			await InitializeUser(user1);


			// act
			var result = await _userService.GetByIdAsync(user1.Id);


			// assert
			Assert.IsNotNull(result);
			Assert.AreEqual(user1, result);
		}

		[TestMethod()]

		public async Task UpdateAsync_ShouldUpdateUser()
		{
			// arrange

			User user1 = CreateUser("George", "Lukas");

			await InitializeUser(user1);

			user1.FirstName = "TestFirstName";
			user1.LastName = "TestLastName";

			// act
			var result = await _userService.UpdateAsync(user1);

			// assert

			Assert.IsNotNull(result);
			Assert.AreEqual(user1.FirstName, result.FirstName);
			Assert.AreEqual(user1.LastName, result.LastName);

		}



	}

}