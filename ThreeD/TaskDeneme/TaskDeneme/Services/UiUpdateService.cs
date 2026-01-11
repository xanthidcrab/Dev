using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDeneme.Model;
using TaskDeneme.Services.Contracts;

namespace TaskDeneme.Services
{
    public class UiUpdateService : IUiUpdateService
    {
        private readonly IProgress<Action> _ui;

        public UiUpdateService()
        {
            _ui = new Progress<Action>(action => action());
        }

        

        public void UptadeAxisVariables(AxisModel model)
        {
            _ui.Report(() =>
            {
                model.ActualPos += 1;
            model.TargetPos += 1;
            model.Velocity += 1;
            model.Acceleration += 1;
            model.Deceleration += 1;
            model.Jerk += 1;
            });
        }
    }

}
