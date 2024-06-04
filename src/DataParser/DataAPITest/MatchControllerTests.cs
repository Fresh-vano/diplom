using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataAPI.Models;
using DataAPI.Data;
using DataAPI.Controllers;

namespace DataAPITest
{
	public class MatchControllerTests
	{
		[Fact]
		public void GetFinishedMatches_ReturnsOkResult_WithListOfFinishedMatches()
		{
			// Arrange
			var mockContext = new Mock<Cs2Context>();
			mockContext.Setup(c => c.Matches).Returns(MockDbSet(new List<DataAPI.Models.Match>
		{
			new DataAPI.Models.Match { Slug = "match1", EndDate = DateTime.UtcNow.AddDays(-1) }
		}));
			var controller = new MatchController(mockContext.Object);

			// Act
			var result = controller.GetFinishedMatches();

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var returnValue = Assert.IsAssignableFrom<object>(okResult.Value);
			Assert.NotNull(returnValue);
		}

		[Fact]
		public void GetCurrentMatches_ReturnsOkResult_WithListOfCurrentMatches()
		{
			// Arrange
			var mockContext = new Mock<Cs2Context>();
			mockContext.Setup(c => c.Matches).Returns(MockDbSet(new List<DataAPI.Models.Match>
		{
			new DataAPI.Models.Match { Slug = "match1", StartDate = DateTime.UtcNow.AddDays(-1), EndDate = DateTime.UtcNow.AddDays(1) }
		}));
			var controller = new MatchController(mockContext.Object);

			// Act
			var result = controller.GetCurrentMatches();

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
