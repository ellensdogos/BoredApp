using System;
using System.Net.Http;
using System.Threading.Tasks;
using BoredApp.Models;
using Newtonsoft.Json;

namespace BoredApp.Services
{
    public class ApiService : IApiService
    {
        private async Task<string> Get(string url)
        {
            var client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(url);

            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadAsStringAsync();
            }

            return "Something went wrong!";
        }

        public async Task<Activity> GetRandomActivity()
        {
            var data = await Get("https://www.boredapi.com/api/activity/");
            return JsonConvert.DeserializeObject<Activity>(data);
        }

        public async Task<Person> GetAgeByName(string name)
        {
            var data = await Get("https://api.agify.io/?name=" + name);
            return JsonConvert.DeserializeObject<Person>(data);
        }

        public async Task<Person> GetGenderByName(string name)
        {
            var data = await Get("https://api.genderize.io/?name=" + name);
            return JsonConvert.DeserializeObject<Person>(data);
        }
    }
}
