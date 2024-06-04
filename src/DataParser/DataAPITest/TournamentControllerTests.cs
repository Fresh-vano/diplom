using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using DataAPI.Data;
using DataAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using DataAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAPITest
{
	public class TournamentControllerTests
	{
		[Fact]
		public void GetCurrentTournaments_ReturnsOkResult_WithListOfCurrentTournaments()
		{
			// Arrange
			var mockContext = new Mock<Cs2Context>();
			mockContext.Setup(c => c.Tournaments).Returns(MockDbSet(new List<Tournament>
		{
			new Tournament { Slug = "tournament1", StartDate = DateTime.UtcNow.AddDays(1) }
		}));
			var controller = new TournamentController(mockContext.Object);

			// Act
			var result = controller.GetCurrentTournaments();

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var returnValue = Assert.IsAssignableFrom<object>(okResult.Value);
			Assert.NotNull(returnValue);
		}

		[Fact]
		public void GetFinishedTournaments_ReturnsOkResult_WithListOfFinishedTournaments()
		{
			// Arrange
			var mockContext = new Mock<Cs2Context>();
			mockContext.Setup(c => c.Tournaments).Returns(MockDbSet(new List<Tournament>
		{
			new Tournament { Slug = "tournament1", EndDate = DateTime.UtcNow.AddDays(-1) }
		}));
			var controller = new TournamentController(mockContext.Object);

			// Act
			var result = controller.GetFinishedTournaments();

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var returnValue = Assert.IsAssignableFrom<object>(okResult.Value);
			Assert.NotNull(returnValue);
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
