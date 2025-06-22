using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace S.A.M.Helper.Email.BackgroundQueue
{
    public class EmailQueuedHostedService : BackgroundService
    {
        private readonly ILogger _logger;

        public EmailQueuedHostedService(IEmailBackgroundTaskQueue taskQueue,
            ILoggerFactory loggerFactory)
        {
            TaskQueue = taskQueue;
            _logger = loggerFactory.CreateLogger<EmailQueuedHostedService>();
        }

        public IEmailBackgroundTaskQueue TaskQueue { get; }

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
                    if(!operationFinished)
                        TaskQueue.QueueBackgroundWorkItem(workItem);
                }
                
            }

            _logger.LogInformation("Queued Hosted Service is stopping.");
        }
    }
}
