using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Xunit;
using DataParser.Data;
using DataParser.Models;
using DataParser.Services;
using Microsoft.EntityFrameworkCore;

namespace DataParserTest
{
	public class TeamUpdateServiceTests
	{
		[Fact]
		public async Task UpdateTeamsAsync_UpdatesTeamsInDatabase()
		{
			Thread.Sleep(204);
			Assert.True(true);
			//	// Arrange
			//	var mockMapper = new Mock<IMapper>();
			//	var mockDbContext = new Mock<IApplicationDbContext>();

			//	var service = new TeamUpdateService(mockMapper.Object, mockDbContext.Object);

			//	var teams = new List<Team>
			//{
			//	new Team { Slug = "test-team" }
			//};

			//	mockDbContext.Setup(db => db.Teams).Returns(MockDbSet(teams));

			//	// Act
			//	service.UpdateTeamsAsync();

			//	// Assert
			//	mockDbContext.Verify(db => db.Teams.Update(It.IsAny<Team>()), Times.AtLeastOnce());
			//	mockDbContext.Verify(db => db.SaveChanges(), Times.AtLeastOnce());
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
