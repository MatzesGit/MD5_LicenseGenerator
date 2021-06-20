using LicenseGenerator.Core;

namespace LicenseGenerator.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        // Interface

        public RelayCommand GenerateViewCommand { get; set; }

        public RelayCommand ManageMachinesViewCommand { get; set; }

        public RelayCommand SettingsViewCommand { get; set; }

        public RelayCommand AboutViewCommand { get; set; }

        public GenerateViewModel GenerateVM{ get; set;}

        public ManageMachinesViewModel ManageMachinesVM { get; set; }

        public SettingsViewModel SettingsVM { get; set; }

        public AboutViewModel AboutVM { get; set; }


        private object _currentView;

        // Property

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value;
                OnPropertyChanged();
            }
        }
        
        public MainViewModel()
        {
            GenerateVM = new GenerateViewModel();
            ManageMachinesVM = new ManageMachinesViewModel();
            SettingsVM = new SettingsViewModel();
            AboutVM = new AboutViewModel();

            CurrentView = GenerateVM;

            GenerateViewCommand = new RelayCommand(o =>
            {
                CurrentView = GenerateVM;
            });

            ManageMachinesViewCommand = new RelayCommand(o =>
            {
                CurrentView = ManageMachinesVM;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVM;
            });

            AboutViewCommand = new RelayCommand(o =>
            {
                CurrentView = AboutVM;
            });
        }
    }
}
