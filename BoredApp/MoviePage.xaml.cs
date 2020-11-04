using BoredApp.Viewmodels;

using Xamarin.Forms;

namespace BoredApp
{
    public partial class MoviePage : ContentPage
    {
        MoviePageViewModel viewModel;

        public MoviePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MoviePageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                DescriptionLabel.IsVisible = true;
                DescriptionLabel.Text = viewModel.Movie.Description;
                viewModel.LoadButtons();
            }
        }
    }
}
