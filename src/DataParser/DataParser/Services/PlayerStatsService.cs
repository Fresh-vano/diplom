using AutoMapper;
using DataParser.Data;
using DataParser.DTOs;
using DataParser.Models;
using Newtonsoft.Json;

namespace DataParser.Services
{
	public class PlayerStatsService : IPlayerStatsService
	{
		static readonly HttpClient client = new HttpClient();
		private readonly IMapper _mapper;
		private readonly IApplicationDbContext _dbContext;

		public PlayerStatsService(IMapper mapper, IApplicationDbContext dbContext)
		{
			_mapper = mapper;
			_dbContext = dbContext;
		}

		public async Task AddPlayerStatsAsync(Map map)
		{
			try
			{
				await Console.Out.WriteLineAsync($"========================================           Map: {map.Id}");

				var url = $"https://api.bo3.gg/api/v1/games/${map.Id}/players_stats";

				HttpClientHelper.ConfigureClient(client, $"https://bo3.gg/ru/matches/{map.Match.Slug}/{map.MapName}");

				var response = await client.GetAsync(url);
				response.EnsureSuccessStatusCode();
				var responseBody = await response.Content.ReadAsStringAsync();

				var dtos = JsonConvert.DeserializeObject<PlayerStatsDto>(responseBody);

				foreach (var stat in dtos.stats)
				{
					var playerStat = _mapper.Map<PlayerStats>(stat);

					if (!_dbContext.PlayerStats.Any(x => x.Id == playerStat.Id))
					{
						_dbContext.PlayerStats.Add(playerStat);
						_dbContext.SaveChanges();
					}
				}

				await Task.Delay(TimeSpan.FromSeconds(5));
			}
			catch (HttpRequestException e)
			{
				await Console.Out.WriteLineAsync("\nException Caught!");
				await Console.Out.WriteLineAsync($"Message :{e.Message} ");
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync("\nException Caught!");
				await Console.Out.WriteLineAsync($"Message :{ex.Message} ");
			}
		}
	}
}
