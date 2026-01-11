using MVVM_Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MVVM_Base
{
    public class PlcService<TGlobal> where TGlobal : class, new()
    {
        private readonly IPlcAdapter<TGlobal> _adapter;
        private readonly TGlobal _globals;
        private readonly Timer _timer;

        public PlcService(IPlcAdapter<TGlobal> adapter)
        {
            _adapter = adapter;
            _globals = new TGlobal();
            _timer = new Timer(async _ => await UpdateLoop(), null, Timeout.Infinite, Timeout.Infinite);
        }

        public TGlobal Globals => _globals;

        public async Task StartAsync()
        {
            if (await _adapter.ConnectAsync())
                _timer.Change(0, 60);
        }

        public async Task StopAsync()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            await _adapter.DisconnectAsync();
        }

        private async Task UpdateLoop()
        {
            try
            {
                await _adapter.ReadGlobalVariablesAsync(_globals);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
