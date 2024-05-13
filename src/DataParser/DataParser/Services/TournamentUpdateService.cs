
using AutoMapper;
using DataParser.Data;
using DataParser.DTOs;
using DataParser.Models;
using Newtonsoft.Json;

namespace DataParser.Services
{
	public class TournamentUpdateService : ITournamentUpdateService
	{
		static readonly HttpClient client = new HttpClient();
		private int offset = 0;
		private readonly int limit = 50;
		private readonly IMapper _mapper;
		private readonly IApplicationDbContext _dbContext;
		private int count = 50;

		public TournamentUpdateService(IMapper mapper, IApplicationDbContext dbContext)
		{
			_mapper = mapper;
			_dbContext = dbContext;
		}

		public async Task UpdateTournamentAsync()
		{
			await UpdateTournamentMinFinishedAsync();
			await UpdateTournamentMinUpcomingAsync();

			try
			{
				var tournaments = _dbContext.Tournaments.ToList();

				foreach (var tournament in tournaments)
				{
					await Console.Out.WriteLineAsync($"========================================           Tournament offset: {tournament.Name}");

					var url = $"https://api.bo3.gg/api/v1/tournaments/{tournament.Slug}";

					HttpClientHelper.ConfigureClient(client, $"https://bo3.gg/ru/tournaments/{tournament.Slug}");

					var response = await client.GetAsync(url);
					response.EnsureSuccessStatusCode();
					var responseBody = await response.Content.ReadAsStringAsync();

					var tournamentFullDtoData = JsonConvert.DeserializeObject<TournamentFullDto>(responseBody);

					var tournamentFull = _mapper.Map<Tournament>(tournamentFullDtoData);

					if (tournament.Id == tournamentFull.Id)
					{
						if (tournamentFull.Stages != null)
						{
							foreach (var stage in tournamentFull.Stages)
							{
								stage.TournamentId = tournamentFull.Id;
								_dbContext.Stages.Add(stage);

							}
							_dbContext.SaveChanges();
						}

						tournament.Discipline = tournamentFull.Discipline;
						tournament.EventType = tournamentFull.EventType;
						tournament.Description = tournamentFull.Description;
						tournament.ImageUrl = tournamentFull.ImageUrl;
						tournament.Country = tournamentFull.Country;
						tournament.Stages = tournamentFull.Stages;
						tournament.UpdatedAt = DateTime.UtcNow;


						_dbContext.Tournaments.Update(tournament);
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

		public async Task UpdateTournamentMinFinishedAsync()
		{
			try
			{
				for (offset = 0; offset < count; offset += limit)
				{
					await Console.Out.WriteLineAsync($"========================================           Tournament offset: {offset}");

					var url = $"https://api.bo3.gg/api/v1/tournaments?scope=index-finished-tournaments&" +
							  $"page[offset]={offset}&page[limit]={limit}&" +
							  $"sort=-end_date&filter[tournaments.status][in]=finished&" +
							  $"filter[tournaments.discipline_id][eq]=1&with=teams,tournament_prizes,locations,";

					HttpClientHelper.ConfigureClient(client, $"https://bo3.gg/ru/tournaments/finished");

					var response = await client.GetAsync(url);
					response.EnsureSuccessStatusCode();
					var responseBody = await response.Content.ReadAsStringAsync();

					var tournamentDtoData = JsonConvert.DeserializeObject<TournamentGeneralDto>(responseBody);

					count = tournamentDtoData.Total.Count;

					foreach (var tournamentDto in tournamentDtoData.TournamentMin)
					{
						var tournament = _mapper.Map<Tournament>(tournamentDto);

						if (_dbContext.Tournaments.FirstOrDefault(t => t.Id == tournament.Id) == default)
						{
							tournament.CreatedAt = DateTime.UtcNow;
							_dbContext.Tournaments.Add(tournament);
							_dbContext.SaveChanges();
							await Console.Out.WriteLineAsync($"Tournament add: {tournament.Name}");
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

		public async Task UpdateTournamentMinUpcomingAsync()
		{
			try
			{
				for (offset = 0; offset < count; offset += limit)
				{
					await Console.Out.WriteLineAsync($"========================================           Tournament offset: {offset}");

					var url = $"https://api.bo3.gg/api/v1/tournaments?scope=index-finished-tournaments&" +
							  $"page[offset]={offset}&page[limit]={limit}&" +
							  $"sort=-end_date&filter[tournaments.status][in]=current,upcoming&" +
							  $"filter[tournaments.discipline_id][eq]=1&with=teams,tournament_prizes,locations,";

					HttpClientHelper.ConfigureClient(client, $"https://bo3.gg/ru/tournaments/finished");

					var response = await client.GetAsync(url);
					response.EnsureSuccessStatusCode();
					var responseBody = await response.Content.ReadAsStringAsync();

					var tournamentDtoData = JsonConvert.DeserializeObject<TournamentGeneralDto>(responseBody);

					count = tournamentDtoData.Total.Count;

					foreach (var tournamentDto in tournamentDtoData.TournamentMin)
					{
						var tournament = _mapper.Map<Tournament>(tournamentDto);

						if (_dbContext.Tournaments.FirstOrDefault(t => t.Id == tournament.Id) == default)
						{
							tournament.CreatedAt = DateTime.UtcNow;
							_dbContext.Tournaments.Add(tournament);
							_dbContext.SaveChanges();
							await Console.Out.WriteLineAsync($"Tournament add: {tournament.Name}");
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
