using BoredApp.Viewmodels;

using Xamarin.Forms;

namespace BoredApp
{
    public partial class PredictPage : ContentPage
    {
        PredictPageViewModel viewModel;

        public PredictPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new PredictPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
