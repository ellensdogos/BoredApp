using System.Windows.Input;
using System.Threading.Tasks;
using BoredApp.Models;
using Xamarin.Forms;

namespace BoredApp.Viewmodels
{
    public class PredictPageViewModel : BaseViewModel
    {
        private Person person;

        private bool isAgeVisible;
        private bool isGenderVisible;

        public ICommand LoadAgeByNameCommand { get; }
        public ICommand LoadGenderByNameCommand { get; }


        public PredictPageViewModel()
        {
            LoadAgeByNameCommand = new Command<string>(async (name) => await LoadAgeByName(name));
            LoadGenderByNameCommand = new Command<string>(async (name) => await LoadGenderByName(name));
        }

        public Person Person
        {
            get { return person; }

            set
            {
                if (person != value)
                {
                    person = value;

                    OnPropertyChanged();
                }
            }
        }

        public bool IsAgeVisible
        {
            get { return isAgeVisible; }

            set
            {
                if (isAgeVisible != value)
                {
                    isAgeVisible = value;

                    OnPropertyChanged();
                }
            }
        }

        public bool IsGenderVisible
        {
            get { return isGenderVisible; }

            set
            {
                if (isGenderVisible != value)
                {
                    isGenderVisible = value;

                    OnPropertyChanged();
                }
            }
        }

        public async Task LoadAgeByName(string name)
        {
            IsGenderVisible = false;
            IsAgeVisible = true;
            Person = await ApiService.GetAgeByName(name);
        }

        public async Task LoadGenderByName(string name)
        {
            IsAgeVisible = false;
            IsGenderVisible = true;
            Person = await ApiService.GetGenderByName(name);
        }
    }
}
