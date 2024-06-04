using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Xunit;
using DataParser.Data;
using DataParser.DTOs;
using DataParser.Models;
using DataParser.Services;
using Microsoft.EntityFrameworkCore;

namespace DataParserTest
{
	public class PlayerStatsServiceTests
	{
		[Fact]
		public async Task AddPlayerStatsAsync_AddsStatsToDatabase()
		{
			// Arrange
			var mockMapper = new Mock<IMapper>();
			var mockDbContext = new Mock<IApplicationDbContext>();
			var service = new PlayerStatsService(mockMapper.Object, mockDbContext.Object);

			var map = new Map { Id = 1, Match = new DataParser.Models.Match { Slug = "test-slug" }, MapName = DataParser.Enums.MapNameEnum.de_mirage };

			var playerStatsDto = new PlayerStatsDto
			{
				stats = new List<StatsDto>
			{
				new StatsDto { Id = 1, PlayerId = new StatsDto.NestedPlayerDto{ Id = 1 } }
			}
			};

			mockMapper.Setup(m => m.Map<PlayerStats>(It.IsAny<PlayerStats>()))
					  .Returns(new PlayerStats { Id = 1, PlayerId = 1 });

			mockDbContext.Setup(db => db.PlayerStats).Returns(MockDbSet(new List<PlayerStats>()));

			// Act
			await service.AddPlayerStatsAsync(map);

			// Assert
			mockDbContext.Verify(db => db.PlayerStats.Add(It.IsAny<PlayerStats>()), Times.AtLeastOnce());
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
