using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using TaskDeneme.Model;
using TaskDeneme.Services.Contracts;

namespace TaskDeneme.ViewModel
{
    public partial class ControlViewModel : ObservableObject
    {
        private readonly IPollingService polling;
        private readonly IProgress<Action> _ui;
        [ObservableProperty] AxisModel selectedAxis;
        [ObservableProperty] ObservableCollection<AxisModel>  axisList;
        [ObservableProperty] string number;

        public ControlViewModel(IPollingService polling)
        {
            AxisList = [];
            this.polling = polling;
            _ui = new Progress<Action>(action => action());

            AssingMockModels();
            
            
        }
        partial void OnNumberChanged(string value)
        {
            // Handle the change in Number property here
            // For example, you can validate the input or perform some action
        }
        private void AssingMockModels()
        {
            for (int i = 0; i < 32; i++)
            {
                AxisModel axisModel = new();
                axisModel.Id = i;
                axisModel.ActualPos = 0;
                axisModel.TargetPos = 0;
                axisModel.Velocity = 0;
                axisModel.Acceleration = 0;
                axisModel.Deceleration = 0;
                axisModel.Jerk = 0;
                axisModel.Manual = new bool[4] { false, false, false, false };
                AxisList.Add(axisModel);
            }
        }
        private void Cycle() 
        {

            if (SelectedAxis == null)
                return;

            //App.Current.Dispatcher.Invoke(() =>
            //{
            _ui.Report(() =>
            {
                // UI THREAD
            
            });
          
                
            //});
        }
        [RelayCommand]
        private void Start()
        {
            polling.StartPolling(Cycle, 200);
        }


        [RelayCommand]
        private void Stop()
        {
            polling.StopPolling();
        }
    }
}
