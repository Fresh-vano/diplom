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
	public class TournamentUpdateServiceTests
	{
		[Fact]
		public async Task UpdateTournamentAsync_UpdatesTournamentsInDatabase()
		{
			// Arrange
			var mockMapper = new Mock<IMapper>();
			var mockDbContext = new Mock<IApplicationDbContext>();

			var service = new TournamentUpdateService(mockMapper.Object, mockDbContext.Object);

			var tournaments = new List<Tournament>
			{
				new Tournament { Slug = "test-tournament" }
			};

			mockDbContext.Setup(db => db.Tournaments).Returns(MockDbSet(tournaments));

			// Act
			await service.UpdateTournamentAsync();

			// Assert
			mockDbContext.Verify(db => db.Tournaments.Update(It.IsAny<Tournament>()), Times.AtLeastOnce());
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
