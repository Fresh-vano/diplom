using AutoMapper;
using DataParser.Data;
using DataParser.DTOs;
using DataParser.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DataParser.Services
{
	public class TeamUpdateService : ITeamUpdateService
	{
		static readonly HttpClient client = new HttpClient();
		private int offset = 0;
		private readonly int limit = 30;
		private readonly IMapper _mapper;
		private readonly IApplicationDbContext _dbContext;
		private int count = 30;

		public TeamUpdateService(IMapper mapper, IApplicationDbContext dbContext)
		{
			_mapper = mapper;
			_dbContext = dbContext;
		}

		public async Task UpdateTeamsAsync()
		{
			try
			{
				for (offset = 0; offset < count; offset += limit)
				{
					await Console.Out.WriteLineAsync($"========================================           {offset}");

					var url = $"https://api.bo3.gg/api/v1/teams/rankings/earn?" +
							  $"page[offset]={offset}&page[limit]={limit}&" +
							  $"sort=rank&filter[current][eq]=true&with=team,team_roster";

					HttpClientHelper.ConfigureClient(client, $"https://bo3.gg/teams/earnings?page={offset / limit + 1}");

					var response = await client.GetAsync(url);
					response.EnsureSuccessStatusCode();
					var responseBody = await response.Content.ReadAsStringAsync();

					var teamDtoData = JsonConvert.DeserializeObject<TeamGeneralDTO>(responseBody);

					count = teamDtoData.Total.Count;

					foreach (var teamRankDto in teamDtoData.TeamRanks)
					{
						var country = _mapper.Map<Country>(teamRankDto.Team.Country);

						if (country != null)
							SaveToDatabase(country);

						var team = _mapper.Map<Team>(teamRankDto.Team);
						if (team == null)
							continue;
						var existingTeam = _dbContext.Teams.FirstOrDefault(t => t.Id == team.Id);
						if (existingTeam == default)
						{
							await Console.Out.WriteLineAsync($"Adding team: {team.Name}");

							team.CreatedAt = DateTimeOffset.UtcNow;
							team.Country = null;
							team.Players = new List<Player>();

							_dbContext.Teams.Add(team);
							_dbContext.SaveChanges();
						}


						foreach (var roster in teamRankDto.TeamRoster.Players)
						{
							var player = _mapper.Map<Player>(roster);
							if (player == null)
								continue;
							var existingPlayer = _dbContext.Players.FirstOrDefault(t => t.Id == player.Id);

							if (player.Country != null)
								SaveToDatabase(player.Country);

							if (existingPlayer == default)
							{
								await Console.Out.WriteLineAsync($"Adding player: {player.Nickname}");

								player.CreatedAt = DateTimeOffset.UtcNow;
								player.Country = null;
								player.Team = null;

								if (player.TeamId != null)
								{
									if (player.TeamId == team.Id)
									{
										if (team.Players == null)
											team.Players = new List<Player>();

										team.Players.Add(player);
									}
									else
									{
										var existingPlayerTeam = _dbContext.Teams.FirstOrDefault(t => t.Id == player.TeamId);
										if (existingPlayerTeam != default)
										{
											if (existingPlayerTeam.Players == null)
												existingPlayerTeam.Players = new List<Player>();

											existingPlayerTeam.Players.Add(player);
											_dbContext.SaveChanges();
										}
										else
										{
											player.TeamId = null;
										}
									}
								}

								_dbContext.Players.Add(player);
							}
						}
						_dbContext.SaveChanges();
					}

					await Task.Delay(TimeSpan.FromSeconds(4));
				}

				await UpdateTeamNameAsync();
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


		private void SaveToDatabase(Country country)
		{
			var existingCountry = _dbContext.Countries.FirstOrDefault(t => t.Id == country.Id);
			if (existingCountry == default)
			{
				_dbContext.Countries.Add(country);
			}

			_dbContext.SaveChanges();
		}

		public async Task UpdateTeamNameAsync()
		{
			try
			{
				var teams = _dbContext.Teams.ToList();

				foreach (Team team in teams)
				{
					await Console.Out.WriteLineAsync($"========================================           TEAM {team.Name}");

					var url = $"https://api.bo3.gg/api/v1/teams/{team.Slug}";

					HttpClientHelper.ConfigureClient(client, $"https://bo3.gg/ru/teams/{team.Slug}");
						
					var response = await client.GetAsync(url);
					response.EnsureSuccessStatusCode();
					var responseBody = await response.Content.ReadAsStringAsync();

					List<TeamClanDto> teamClans = JsonConvert.DeserializeObject<List<TeamClanDto>>(JsonConvert.SerializeObject(JsonConvert.DeserializeObject<dynamic>(responseBody).team_clans));

					foreach (var teamClan in teamClans)
					{
						TeamName teamName = _mapper.Map<TeamName>(teamClan);

						var existingTeamName = _dbContext.TeamNames.FirstOrDefault(tn => tn.Id == teamName.Id);
						if (existingTeamName == default)
						{
							_dbContext.TeamNames.Add(teamName);
						}
					}

					_dbContext.SaveChanges();
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
