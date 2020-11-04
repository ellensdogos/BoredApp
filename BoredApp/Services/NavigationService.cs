using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BoredApp.Services
{
    public class NavigationService : INavigationService
    {
        private Page MainPage => Application.Current.MainPage;

        public async Task GoToPredictPage()
        {
            await MainPage.Navigation.PushAsync(new PredictPage());
        }

        public async Task GoToMoviePage()
        {
            await MainPage.Navigation.PushAsync(new MoviePage());
        }
    }
}
