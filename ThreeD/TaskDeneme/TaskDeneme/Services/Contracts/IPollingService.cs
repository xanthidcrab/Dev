using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDeneme.Services.Contracts
{
    public interface IPollingService : IDisposable
    {
        void StartPolling(Action action, int time);
        void StopPolling();
    }
}
