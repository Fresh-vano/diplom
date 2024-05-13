using DataParser.BackgroundService;

public class Worker : Microsoft.Extensions.Hosting.BackgroundService
{
	private readonly IBackgroundTaskQueue _taskQueue;

	public Worker(IBackgroundTaskQueue taskQueue)
	{
		_taskQueue = taskQueue;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		while (!stoppingToken.IsCancellationRequested)
		{
			var workItem = await _taskQueue.DequeueAsync(stoppingToken);

			try
			{
				await workItem(stoppingToken);
			}
			catch (Exception ex)
			{
			}
		}
	}
}
