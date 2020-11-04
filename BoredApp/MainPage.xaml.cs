using Xamarin.Forms;
using BoredApp.Viewmodels;

namespace BoredApp
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MainPageViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await viewModel.LoadActivity();
        }
    }
}
