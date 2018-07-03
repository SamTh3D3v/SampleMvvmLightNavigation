using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Chargily.Helpers;

namespace Chargily.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private RelayCommand _loadedCommand;            
        public RelayCommand LoadedCommand
        {
            get
            {
                return _loadedCommand
                    ?? (_loadedCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("Home");
                    }));
            }
        }

        public MainViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}