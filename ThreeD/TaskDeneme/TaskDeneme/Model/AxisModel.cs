using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDeneme.Model
{
    public partial class AxisModel : ObservableObject
    {
        [ObservableProperty]private int id ;
        [ObservableProperty]private double actualPos ;
        [ObservableProperty]private double targetPos ;
        [ObservableProperty]private double velocity ;
        [ObservableProperty]private double acceleration ;
        [ObservableProperty]private double deceleration ;
        [ObservableProperty]private double jerk ;
        [ObservableProperty]private bool[] manual ;
    }
}
