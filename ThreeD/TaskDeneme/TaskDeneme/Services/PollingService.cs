using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDeneme.Services.Contracts;

namespace TaskDeneme.Services
{
    public class PollingService : IPollingService
    {
        private CancellationTokenSource _cts;
        private Task? _pollingTask;
        private readonly object _lock = new();

        public void StartPolling(Action action, int intervalMs)
        {
            ArgumentNullException.ThrowIfNull(action);

            lock (_lock)
            {
                StopPolling();

                _cts = new CancellationTokenSource();

                _pollingTask = Task.Run(async () =>
                {
                    try
                    {
                        while (!_cts.Token.IsCancellationRequested)
                        {
                            try
                            {
                                action();
                            }
                            catch (Exception ex)
                            {
                                // LOG AT → çok önemli
                                Debug.WriteLine(ex);
                            }

                            await Task.Delay(intervalMs, _cts.Token);
                        }
                    }
                    catch (TaskCanceledException)
                    {
                        // Normal shutdown
                    }
                }, _cts.Token);
            }
        }

        public void StopPolling()
        {
            lock (_lock)
            {
                if (_cts == null)
                    return;

                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
                _pollingTask = null;
            }
        }

        public void Dispose() => StopPolling();
    }

}
