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
	public class MatchUpdateServiceTests
	{
		[Fact]
		public async Task UpdateMatchAsync_UpdatesMatchesInDatabase()
		{
			// Arrange
			var mockMapper = new Mock<IMapper>();
			var mockDbContext = new Mock<IApplicationDbContext>();
			var playerStatsService = new Mock<IPlayerStatsService>();

			var service = new MatchUpdateService(mockMapper.Object, mockDbContext.Object);

			var matches = new List<DataParser.Models.Match>
		{
			new DataParser.Models.Match { Slug = "test-slug" }
		};

			mockDbContext.Setup(db => db.Matches).Returns(MockDbSet(matches));

			// Act
			await service.UpdateMatchAsync();

			// Assert
			mockDbContext.Verify(db => db.Matches.Update(It.IsAny<DataParser.Models.Match>()), Times.AtLeastOnce());
			mockDbContext.Verify(db => db.SaveChanges(), Times.AtLeastOnce());
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
