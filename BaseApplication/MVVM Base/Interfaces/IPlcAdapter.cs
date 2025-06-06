using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Base.Interfaces
{
    public interface IPlcAdapter<TGlobal> where TGlobal : class, new()
    {
        Task<bool> ConnectAsync();
        Task DisconnectAsync();
        Task ReadGlobalVariablesAsync(TGlobal globalVars);
    }
}
