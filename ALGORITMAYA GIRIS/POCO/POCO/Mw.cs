using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Mw : MVVM_Base.ObserrvableObject
    {

        private GlobalModel _globalModel;

        public GlobalModel GlobalModel
        {
            get { return _globalModel; }
            set { SetProperty(ref _globalModel, value); }
        }



        public Mw()
        {
            GlobalModel = new GlobalModel();    
            PlcService plcService = new PlcService(GlobalModel);
            plcService.StartPooling();
        }



    }
}
