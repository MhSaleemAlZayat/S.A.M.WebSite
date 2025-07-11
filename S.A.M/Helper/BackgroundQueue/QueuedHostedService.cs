﻿namespace S.A.M.Helper.BackgroundQueue;

public class QueuedHostedService : BackgroundService
{
    private readonly ILogger _logger;

    public QueuedHostedService(IBackgroundTaskQueue taskQueue,
        ILoggerFactory loggerFactory)
    {
        TaskQueue = taskQueue;
        _logger = loggerFactory.CreateLogger<QueuedHostedService>();
    }

    public IBackgroundTaskQueue TaskQueue { get; }

    protected async override Task ExecuteAsync(
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Queued Hosted Service is starting.");

        while (!cancellationToken.IsCancellationRequested)
        {
            var workItem = await TaskQueue.DequeueAsync(cancellationToken);
            bool operationFinished = true;
            try
            {
                await workItem(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                   $"Error occurred executing {nameof(workItem)}.");
                operationFinished = false;
            }
            finally
            {
                if (!operationFinished)
                    TaskQueue.QueueBackgroundWorkItem(workItem);
            }

        }

        _logger.LogInformation("Queued Hosted Service is stopping.");
    }
}
