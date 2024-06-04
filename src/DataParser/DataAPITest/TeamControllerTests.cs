using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using DataAPI.Data;
using DataAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using DataAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAPITest
{
	public class TeamControllerTests
	{
		[Fact]
		public void GetAllTeams_ReturnsOkResult_WithListOfTeams()
		{
			// Arrange
			var mockContext = new Mock<Cs2Context>();
			mockContext.Setup(c => c.Teams).Returns(MockDbSet(new List<Team> { new Team { Slug = "team1" } }));
			var controller = new TeamController(mockContext.Object);

			// Act
			var result = controller.GetAllTeams();

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var returnValue = Assert.IsAssignableFrom<object>(okResult.Value);
			Assert.NotNull(returnValue);
		}

		[Fact]
		public void GetTeamBySlug_ReturnsNotFound_WhenTeamNotExists()
		{
			// Arrange
			var mockContext = new Mock<Cs2Context>();
			mockContext.Setup(c => c.Teams).Returns(MockDbSet(new List<Team>()));
			var controller = new TeamController(mockContext.Object);

			// Act
			var result = controller.GetTeamBySlug("non-existent");

			// Assert
			Assert.IsType<NotFoundResult>(result);
		}

		private DbSet<T> MockDbSet<T>(List<T> elements) where T : class
		{
			var queryable = elements.AsQueryable();
			var dbSet = new Mock<DbSet<T>>();
			dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
			dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
			dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
			dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
			return dbSet.Object;
		}
	}
}
