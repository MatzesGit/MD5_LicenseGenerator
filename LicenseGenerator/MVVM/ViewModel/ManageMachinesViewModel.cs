using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Data;
using LicenseGenerator.Core;

namespace LicenseGenerator.MVVM.ViewModel
{

    class ManageMachinesViewModel : ObservableObject
    {
        public RelayCommand AddMachineViewCommand { get; set; }

        public UpdateSourceTrigger UpdateSourceTrigger { get; set; }
    }
}

