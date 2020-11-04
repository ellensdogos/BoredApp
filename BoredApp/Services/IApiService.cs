using System;
using System.Threading.Tasks;
using BoredApp.Models;

namespace BoredApp.Services
{
    public interface IApiService
    {
        Task<Activity> GetRandomActivity();

        Task<Person> GetAgeByName(string name);

        Task<Person> GetGenderByName(string name);

    }
}
