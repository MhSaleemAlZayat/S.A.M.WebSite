using System;
using System.Threading;
using System.Threading.Tasks;

namespace S.A.M.Helper.Email.BackgroundQueue
{
    public interface IEmailBackgroundTaskQueue
    {
        void QueueBackgroundWorkItem(Func<CancellationToken, Task> workItem);

        Task<Func<CancellationToken, Task>> DequeueAsync(
            CancellationToken cancellationToken);
    }
}
