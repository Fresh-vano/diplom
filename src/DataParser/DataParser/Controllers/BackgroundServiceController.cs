using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using DataParser.BackgroundService;
using DataParser.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class BackgroundServiceController : ControllerBase
{
	private readonly IBackgroundTaskQueue _taskQueue;
	private readonly IServiceScopeFactory _serviceScopeFactory;
	private readonly IDictionary<string, CancellationTokenSource> _tokens;

	public BackgroundServiceController(
		IBackgroundTaskQueue taskQueue,
		IServiceScopeFactory serviceScopeFactory,
		IDictionary<string, CancellationTokenSource> tokens)
	{
		_taskQueue = taskQueue;
		_serviceScopeFactory = serviceScopeFactory;
		_tokens = tokens;
	}

	[HttpPost("start-team-update")]
	public IActionResult StartTeamUpdateService()
	{
		return StartService("TeamUpdateService", async (serviceProvider, token) =>
		{
			var teamUpdateService = serviceProvider.GetRequiredService<ITeamUpdateService>();
			await teamUpdateService.UpdateTeamsAsync();
		});
	}

	[HttpPost("start-tournament-update")]
	public IActionResult StartTournamentUpdateService()
	{
		return StartService("TournamentUpdateService", async (serviceProvider, token) =>
		{
			var tournamentUpdateService = serviceProvider.GetRequiredService<ITournamentUpdateService>();
			await tournamentUpdateService.UpdateTournamentAsync();
		});
	}

	[HttpPost("start-match-update")]
	public IActionResult StartMatchUpdateService()
	{
		return StartService("MatchUpdateService", async (serviceProvider, token) =>
		{
			var matchUpdateService = serviceProvider.GetRequiredService<IMatchUpdateService>();
			await matchUpdateService.UpdateMatchAsync();
		});
	}

	[HttpPost("stop/{serviceName}")]
	public IActionResult StopService(string serviceName)
	{
		if (_tokens.TryGetValue(serviceName, out var tokenSource))
		{
			tokenSource.Cancel();
			_tokens.Remove(serviceName);
			return Ok($"Background service {serviceName} stopped");
		}

		return NotFound($"Service {serviceName} not found");
	}

	private IActionResult StartService(string serviceName, Func<IServiceProvider, CancellationToken, Task> work)
	{
		var tokenSource = new CancellationTokenSource();
		if (!_tokens.TryAdd(serviceName, tokenSource))
		{
			return BadRequest($"Service {serviceName} is already running.");
		}

		_taskQueue.QueueBackgroundWorkItem(async token =>
		{
			while (!token.IsCancellationRequested)
			{
				using (var scope = _serviceScopeFactory.CreateScope())
				{
					try
					{
						await work(scope.ServiceProvider, token);
					}
					catch (Exception ex)
					{
					}
				}

				try
				{
					await Task.Delay(TimeSpan.FromHours(1), token);
				}
				catch (TaskCanceledException)
				{
					break;
				}
			}
		});

		return Ok($"Background service {serviceName} started");
	}
}
