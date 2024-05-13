using AutoMapper;
using DataParser.Data;
using DataParser.DTOs;
using DataParser.Models;
using Newtonsoft.Json;

namespace DataParser.Services
{
	public class MatchUpdateService : IMatchUpdateService
	{
		static readonly HttpClient client = new HttpClient();
		private int offset = 0;
		private readonly int limit = 100;
		private readonly IMapper _mapper;
		private readonly IApplicationDbContext _dbContext;
		private int count = 100;

		public MatchUpdateService(IMapper mapper, IApplicationDbContext dbContext)
		{
			_mapper = mapper;
			_dbContext = dbContext;
		}

		public async Task UpdateMatchAsync()
		{
			await UpdateMatchMinFinishedAsync();

			try
			{
				var matches = _dbContext.Matches.ToList();

				foreach (var match in matches)
				{
					await Console.Out.WriteLineAsync($"========================================           Match: {match.Slug}");

					var url = $"https://api.bo3.gg/api/v1/matches/{match.Slug}" +
						$"?with=games,streams,teams,tournament_deep,stage";

					HttpClientHelper.ConfigureClient(client, $"https://bo3.gg/ru/matches/finished");

					var response = await client.GetAsync(url);
					response.EnsureSuccessStatusCode();
					var responseBody = await response.Content.ReadAsStringAsync();

					var matchFullDtoData = JsonConvert.DeserializeObject<MatchFullDto>(responseBody);

					var matchFull = _mapper.Map<Match>(matchFullDtoData);

					if (matchFull.Id == matchFullDtoData.Id)
					{
						match.WinnerTeamId = matchFull.WinnerTeamId;
						match.LoserTeamId = matchFull.LoserTeamId;
						match.TournamentID = matchFull.TournamentID;

						await GetMaps(match);

						_dbContext.Matches.Update(match);
						_dbContext.SaveChanges();
					}

					await Task.Delay(TimeSpan.FromSeconds(5));
				}
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

		public async Task GetMaps(Match match)
		{
			await Console.Out.WriteLineAsync($"========================================           Считывание карт для: {match.Slug}");

			var url = $"https://api.bo3.gg/api/v1/games?sort=number&filter[games.match_id][eq]=${match.Id}" +
				$"&with=winner_team_clan,loser_team_clan,game_side_results,game_rounds";

			HttpClientHelper.ConfigureClient(client, $"https://bo3.gg/ru/matches/${match.Slug}");

			var response = await client.GetAsync(url);
			response.EnsureSuccessStatusCode();
			var responseBody = await response.Content.ReadAsStringAsync();

			var mapGeneralDtoData = JsonConvert.DeserializeObject<MapGeneralDto>(responseBody);

			foreach (var mapDto in mapGeneralDtoData.Maps)
			{
				var map = _mapper.Map<Map>(mapDto);

				_dbContext.Maps.Add(map);
			}
			_dbContext.SaveChanges();


		}

		public async Task UpdateMatchMinFinishedAsync()
		{
			try
			{
				for (offset = 0; offset < count; offset += limit)
				{
					await Console.Out.WriteLineAsync($"========================================           Match offset: {offset}");

					var url = $"https://api.bo3.gg/api/v1/matches?scope=index-finished-matches&" +
							  $"page[offset]={offset}&page[limit]={limit}&" +
							  $"&sort=-start_date&filter[matches.status][in]=finished,defwin&" +
							  $"filter[matches.discipline_id][eq]=1&with=teams,tournament,games";

					HttpClientHelper.ConfigureClient(client, $"https://bo3.gg/ru/matches/finished");

					var response = await client.GetAsync(url);
					response.EnsureSuccessStatusCode();
					var responseBody = await response.Content.ReadAsStringAsync();

					var matchDtoData = JsonConvert.DeserializeObject<MatchGeneralDto>(responseBody);

					count = matchDtoData.Total.Count;

					foreach (var matchDto in matchDtoData.MatchtMin)
					{
						var match = _mapper.Map<Match>(matchDto);

						if (_dbContext.Tournaments.FirstOrDefault(t => t.Id == match.Id) == default)
						{
							match.CreatedAt = DateTime.UtcNow;
							match.Discipline = Enums.DisciplineEnum.CS2;
							_dbContext.Matches.Add(match);
							_dbContext.SaveChanges();
						}
					}

					await Task.Delay(TimeSpan.FromSeconds(4));
				}
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
