using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chargily.Helpers;
using GalaSoft.MvvmLight.Command;

namespace Chargily.ViewModel
{
    public class Page2ViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private string _page2Text = "Page 2";
        public string Page2Text
        {
            get
            {
                return _page2Text;
            }

            set
            {
                if (_page2Text == value)
                {
                    return;
                }

                _page2Text = value;
                RaisePropertyChanged();
            }
        }
        private RelayCommand _homeCommand;        

        public RelayCommand HomeCommand
        {
            get
            {
                return _homeCommand
                       ?? (_homeCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("Home");
                           }));
            }
        }

        public Page2ViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

    }
}
