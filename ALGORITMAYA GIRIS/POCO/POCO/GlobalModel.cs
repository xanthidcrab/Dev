using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MVVM_Base;
namespace POCO
{
    public class GlobalModel : ObserrvableObject
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private bool _transferDone;
        public bool TransferDone
        {
            get => _transferDone;
            set => SetProperty(ref _transferDone, value);
        }

        private bool _startforNextJob;
        public bool StartforNextJob
        {
            get => _startforNextJob;
            set => SetProperty(ref _startforNextJob, value);
        }

        private bool _bStart;
        public bool bStart
        {
            get => _bStart;
            set => SetProperty(ref _bStart, value);
        }

        private bool _bStop;
        public bool bStop
        {
            get => _bStop;
            set => SetProperty(ref _bStop, value);
        }

        private bool _bManual;
        public bool bManual
        {
            get => _bManual;
            set => SetProperty(ref _bManual, value);
        }

        private bool _bAutocycle;
        public bool bAutocycle
        {
            get => _bAutocycle;
            set => SetProperty(ref _bAutocycle, value);
        }

        private double _targetXft;
        public double TargetXft
        {
            get => _targetXft;
            set => SetProperty(ref _targetXft, value);
        }

        private double _targetYft;
        public double TargetYft
        {
            get => _targetYft;
            set => SetProperty(ref _targetYft, value);
        }

        private double _targetZft;
        public double TargetZft
        {
            get => _targetZft;
            set => SetProperty(ref _targetZft, value);
        }
        private bool[] _Alarms;
        public bool[] Alarms
        {
            get => _Alarms;
            set => SetProperty(ref _Alarms, value);
        }
    }

    public class PlcService 
    {
        private readonly GlobalModel globals;

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        public PlcService(GlobalModel globalModel)
        {
            globals = globalModel;
        }
       
        public async Task StartPooling()
        {
            // Start a non-blocking background task for polling every 60ms
            await Task.Run(async () =>
            {
                var rand = new Random();
                var token = _cancellationTokenSource.Token;
                try
                {
                    while (!token.IsCancellationRequested)
                    {
                        // Assign random values to the GlobalModel properties
                        //globals.TransferDone = rand.Next(0, 2) == 1;
                        //globals.StartforNextJob = rand.Next(0, 2) == 1;
                        //globals.bStart = rand.Next(0, 2) == 1;
                        //globals.bStop = rand.Next(0, 2) == 1;
                        //globals.bManual = rand.Next(0, 2) == 1;
                        //globals.bAutocycle = rand.Next(0, 2) == 1;
                        // Limit to 3 decimal places
                        globals.TargetXft = Math.Round(rand.NextDouble() * 100, 3);
                        globals.TargetYft = Math.Round(rand.NextDouble() * 100, 3);
                        globals.TargetZft = Math.Round(rand.NextDouble() * 100, 3);
                        globals.Id = rand.Next(1, 1000);
                        await Task.Delay(60, token); // Poll every 60ms without blocking the thread
                    }
                }
                catch (OperationCanceledException)
                {
                    // Task was cancelled, do any cleanup if necessary
                }
            });
        }
        public Task ReadAlarms()
        {
            return Task.Run(async () =>
            {
                var rand = new Random();
                var token = _cancellationTokenSource.Token;
                try
                {
                    while (!token.IsCancellationRequested)
                    {
                        // Simulate reading alarms
                        globals.Alarms = new bool[10];
                        for (int i = 0; i < globals.Alarms.Length; i++)
                        {
                            globals.Alarms[i] = rand.Next(0, 2) == 1;
                        }
                        await Task.Delay(1000, token); // Read alarms every second without blocking the thread
                    }
                }
                catch (OperationCanceledException)
                {
                    // Task was cancelled, do any cleanup if necessary
                }
            });
        }
        public void StopPooling()
        {
            _cancellationTokenSource.Cancel();
        }

    }



}
