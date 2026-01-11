using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewDeneme.Model
{
    public class XMLMODEL
    {
        private PROFILEMODEL _profilesDataTable;
        private ObservableCollection<OPERATIONMODEL> _operationsDataTable;

        public PROFILEMODEL PROFILESDATATABLE
        {
            get => _profilesDataTable;
            set => _profilesDataTable = value;
        }

        public ObservableCollection<OPERATIONMODEL> OPERATIONSDATATABLE
        {
            get => _operationsDataTable;
            set => _operationsDataTable = value;
        }
    }
}
