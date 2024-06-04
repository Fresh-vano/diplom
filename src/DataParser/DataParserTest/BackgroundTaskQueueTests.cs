using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using DataParser.BackgroundService;

namespace DataParserTest
{
	public class BackgroundTaskQueueTests
	{
		[Fact]
		public async Task QueueBackgroundWorkItem_QueuesWorkItem()
		{
			// Arrange
			var queue = new BackgroundTaskQueue();
			Func<CancellationToken, Task> workItem = ct => Task.CompletedTask;

			// Act
			queue.QueueBackgroundWorkItem(workItem);
			var dequeuedWorkItem = await queue.DequeueAsync(CancellationToken.None);

			// Assert
			Assert.NotNull(dequeuedWorkItem);
		}

		[Fact]
		public async Task DequeueAsync_WaitsForWorkItem()
		{
			// Arrange
			var queue = new BackgroundTaskQueue();
			Func<CancellationToken, Task> workItem = ct => Task.CompletedTask;

			var task = Task.Run(async () =>
			{
				await Task.Delay(100);
				queue.QueueBackgroundWorkItem(workItem);
			});

			// Act
			var dequeuedWorkItem = await queue.DequeueAsync(CancellationToken.None);

			// Assert
			Assert.NotNull(dequeuedWorkItem);
			await task;
		}
	}
}