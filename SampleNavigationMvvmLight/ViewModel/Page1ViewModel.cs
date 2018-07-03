using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chargily.Helpers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Chargily.ViewModel
{
    public class Page1ViewModel:ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private string _page1Text ="Page 1";   
        public string Page1Text
        {
            get
            {
                return _page1Text;
            }

            set
            {
                if (_page1Text == value)
                {
                    return;
                }

                _page1Text = value;
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

        public Page1ViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
