using System;
using System.Threading.Tasks;

namespace BoredApp.Services
{
    public interface INavigationService
    {
        Task GoToPredictPage();

        Task GoToMoviePage();
    }
}
