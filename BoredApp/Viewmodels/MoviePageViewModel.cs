using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using BoredApp.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace BoredApp.Viewmodels
{
    public class MoviePageViewModel : BaseViewModel
    {
        public ObservableCollection<Movie> MovieList { get; set; }

        public ObservableCollection<string> WatchList { get; set; }

        private Movie movie;
        private string watchlistButton = "My Watchlist";

        private bool isAddVisible;
        private bool isRemoveVisible;
        private bool isWatchlistVisible;

        public ICommand AddMovieCommand { get; }
        public ICommand RemoveMovieCommand { get; }
        public ICommand ShowWatchlistCommand { get; }

        public MoviePageViewModel()
        {
            MovieList = new ObservableCollection<Movie>();
            WatchList = new ObservableCollection<string>();

            AddMovies();

            /*
            var listString = JsonConvert.SerializeObject(WatchList);
            Application.Current.Properties["myFavourites"] = null;
            Application.Current.Properties["myFavourites"] = listString;
            */

            WatchList.Clear();
            var listofstring = Application.Current.Properties["myMovieList"] as string;
            List<string> newList = JsonConvert.DeserializeObject<List<string>>(listofstring);

            foreach (var item in newList)
            {
                WatchList.Add(item);
            }

            AddMovieCommand = new Command<string>(async (movieTitle) => await AddMovieToWatchlist(movieTitle));
            RemoveMovieCommand = new Command<string>(async (movieTitle) => await RemoveFromWatchlist(movieTitle));
            ShowWatchlistCommand = new Command(() => ShowWatchlist());
        }

        public Movie Movie
        {
            get { return movie; }

            set
            {
                if (movie != value)
                {
                    movie = value;

                    OnPropertyChanged();
                }
            }
        }

        public string WatchlistButton
        {
            get { return watchlistButton; }

            set
            {
                if (watchlistButton != value)
                {
                    watchlistButton = value;

                    OnPropertyChanged();
                }
            }
        }

        public bool IsAddVisible
        {
            get { return isAddVisible; }

            set
            {
                if (isAddVisible != value)
                {
                    isAddVisible = value;

                    OnPropertyChanged();
                }
            }
        }

        public bool IsRemoveVisible
        {
            get { return isRemoveVisible; }

            set
            {
                if (isRemoveVisible != value)
                {
                    isRemoveVisible = value;

                    OnPropertyChanged();
                }
            }
        }

        public bool IsWatchlistVisible
        {
            get { return isWatchlistVisible; }

            set
            {
                if (isWatchlistVisible != value)
                {
                    isWatchlistVisible = value;

                    OnPropertyChanged();
                }
            }
        }

        public void ShowWatchlist()
        {
            if (IsWatchlistVisible == false)
            {
                IsWatchlistVisible = true;
                WatchlistButton = "Hide Watchlist";
            }

            else
            {
                IsWatchlistVisible = false;
                WatchlistButton = "My Watchlist";
            }
        }

        public void LoadButtons()
        {
            if (WatchList.Contains(Movie.Title))
            {
                IsRemoveVisible = true;
                IsAddVisible = false;
            }

            else
            {
                IsAddVisible = true;
                IsRemoveVisible = false;
            }
        }

        private async Task AddMovieToWatchlist(string movieTitle)
        {
            WatchList.Add(movieTitle);

            var listString = JsonConvert.SerializeObject(WatchList);
            WatchList.Clear();

            Application.Current.Properties["myMovieList"] = null;
            await Application.Current.SavePropertiesAsync();

            Application.Current.Properties["myMovieList"] = listString;
            await Application.Current.SavePropertiesAsync();

            var listofstring = Application.Current.Properties["myMovieList"] as string;
            List<string> newList = JsonConvert.DeserializeObject<List<string>>(listofstring);

            foreach (var item in newList)
            {
                WatchList.Add(item);
            }

            IsAddVisible = false;
            IsRemoveVisible = true;
        }

        private async Task RemoveFromWatchlist(string movieTitle)
        {
            WatchList.Remove(movieTitle);

            var listString = JsonConvert.SerializeObject(WatchList);
            WatchList.Clear();

            Application.Current.Properties["myMovieList"] = null;
            await Application.Current.SavePropertiesAsync();

            Application.Current.Properties["myMovieList"] = listString;
            await Application.Current.SavePropertiesAsync();

            var listofstring = Application.Current.Properties["myMovieList"] as string;
            List<string> newList = JsonConvert.DeserializeObject<List<string>>(listofstring);

            foreach (var item in newList)
            {
                WatchList.Add(item);
            }

            IsAddVisible = true;
            IsRemoveVisible = false;
        }

        private void AddMovies()
        {
            MovieList.Add(new Movie { Title = "Bad Boys For Life", Image = "badboys.jpg", Description = "Miami detectives Mike Lowrey and Marcus Burnett must face off against a mother-and-son pair of drug lords who wreak vengeful havoc on their city." });
            MovieList.Add(new Movie { Title = "White House Down", Image = "whitehousedown.jpg", Description = "While on a tour of the White House with his young daughter, a Capitol policeman springs into action to save his child and protect the president from a heavily armed group of paramilitary invaders." });
            MovieList.Add(new Movie { Title = "Avengers", Image = "avengers.jpg", Description = "With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe." });
            MovieList.Add(new Movie { Title = "Central Intelligence", Image = "centralintelligence.jpg", Description = "After he reconnects with an awkward pal from high school through Facebook, a mild-mannered accountant is lured into the world of international espionage." });
            MovieList.Add(new Movie { Title = "The Godfather", Image = "godfather.jpg", Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." });
            MovieList.Add(new Movie { Title = "Hunter Killer", Image = "hunterkiller.jpg", Description = "An untested American submarine captain teams with U.S. Navy Seals to rescue the Russian president, who has been kidnapped by a rogue general." });
            MovieList.Add(new Movie { Title = "Jumanji", Image = "jumanji.jpg", Description = "Four teenagers are sucked into a magical video game, and the only way they can escape is to work together to finish the game." });
            MovieList.Add(new Movie { Title = "Safe Haven", Image = "safehaven.jpg", Description = "A young woman with a mysterious past lands in Southport, North Carolina where her bond with a widower forces her to confront the dark secret that haunts her." });
            MovieList.Add(new Movie { Title = "Girls Trip", Image = "girlstrip", Description = "When four lifelong friends travel to New Orleans for the annual Essence Festival, sisterhoods are rekindled, wild sides are rediscovered, and there's enough dancing, drinking, brawling and romancing to make the Big Easy blush." });
        }
    }
}
