using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using TaskDeneme.Services.Contracts;
using TaskDeneme.ViewModel;

public class PlcPollingBackgroundService : BackgroundService
{
    private readonly ControlViewModel vm;
    private readonly IUiUpdateService _ui;

    public PlcPollingBackgroundService(ControlViewModel vm,

        IUiUpdateService ui)
    {
        this.vm = vm;
        _ui = ui;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {


            // 2️⃣ UI'ya taşı
            if (vm.SelectedAxis != null)
            {

            _ui.UptadeAxisVariables(vm.SelectedAxis);
            }

            // 3️⃣ Periyot
            await Task.Delay(50, stoppingToken);
        }
    }
}
