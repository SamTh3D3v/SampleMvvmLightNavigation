/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:Chargily.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Chargily.Helpers;
using System;

namespace Chargily.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);            
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<Page2ViewModel>();
            SimpleIoc.Default.Register<Page1ViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SetupNavigation();
        }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure("Home", new Uri("../View/Home.xaml", UriKind.Relative));
            navigationService.Configure("Page1", new Uri("../View/Page1.xaml", UriKind.Relative));            
            navigationService.Configure("Page2", new Uri("../View/Page2.xaml", UriKind.Relative));                      
            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public HomeViewModel HomeViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }
        public Page2ViewModel Page2ViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Page2ViewModel>();
            }
        }
        public Page1ViewModel Page1ViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Page1ViewModel>();
            }
        }
        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}