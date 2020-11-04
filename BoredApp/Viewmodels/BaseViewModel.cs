using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BoredApp.Services;
using Xamarin.Forms;

namespace BoredApp.Viewmodels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IApiService ApiService { get; set; }
        public INavigationService NavigationService { get; set; }

        public BaseViewModel()
        {
            try
            {
                ApiService = DependencyService.Get<IApiService>();
                NavigationService = DependencyService.Get<INavigationService>();
            }

            catch
            {

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
