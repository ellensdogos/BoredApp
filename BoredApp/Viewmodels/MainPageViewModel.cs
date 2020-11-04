using System.Threading.Tasks;
using System.Windows.Input;
using BoredApp.Models;
using Xamarin.Forms;

namespace BoredApp.Viewmodels
{
    public class MainPageViewModel : BaseViewModel
    {
        private Activity activity;

        public ICommand LoadActivityCommand { get; }
        public ICommand LoadPredictPageCommand { get; }
        public ICommand LoadMoviePageCommand { get; }

        public MainPageViewModel()
        {
            LoadActivityCommand = new Command(async () => await LoadActivity());
            LoadPredictPageCommand = new Command(async () => await GoToPredictPage());
            LoadMoviePageCommand = new Command(async () => await GoToMoviePage());

        }

        public Activity Activity
        {
            get { return activity; }

            set
            {
                if (activity != value)
                {
                    activity = value;

                    OnPropertyChanged();
                }
            }
        }

        public async Task LoadActivity()
        {
            Activity = await ApiService.GetRandomActivity();
        }

        public async Task GoToPredictPage()
        {
            await NavigationService.GoToPredictPage();
        }

        public async Task GoToMoviePage()
        {
            await NavigationService.GoToMoviePage();
        }
    }
}
