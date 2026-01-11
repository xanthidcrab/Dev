using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DxfService.Contracts
{
    public interface IDxfSerrvice
    {
        PathGeometry DxfToPathGeometry(string filePath);
         

    }
}
