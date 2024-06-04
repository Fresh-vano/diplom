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
	public class PlayerControllerTests
	{
		[Fact]
		public void GetAllPlayers_ReturnsOkResult_WithListOfPlayers()
		{
			// Arrange
			var mockContext = new Mock<Cs2Context>();
			mockContext.Setup(c => c.Players).Returns(MockDbSet(new List<Player> { new Player { Slug = "fallen" } }));
			var controller = new PlayerController(mockContext.Object);

			// Act
			var result = controller.GetAllPlayers();

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var returnValue = Assert.IsAssignableFrom<object>(okResult.Value);
			Assert.NotNull(returnValue);
		}

		[Fact]
		public void GetPlayerBySlug_ReturnsNotFound_WhenPlayerNotExists()
		{
			// Arrange
			var mockContext = new Mock<Cs2Context>();
			mockContext.Setup(c => c.Players).Returns(MockDbSet(new List<Player>()));
			var controller = new PlayerController(mockContext.Object);

			// Act
			var result = controller.GetPlayerBySlug("non-existent");

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